//This file exists in two places. One in DeveloperTools\Neron.UI project and the other in Neuron ESB Sdk\UI.
//The one in the Neuron ESB Sdk is meant for use in type converter forms to scale the form.
//The one in developer tools is for scaling forms in Neuron Explorer.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Diagnostics;
using static System.Windows.Forms.Control;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Neuron.Pipelines.Design;
using Neuron.Explorer.UserControls;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;

namespace Neuron.Explorer
{
    public static class ResizeUtil
    {
        private static float _dpiScalingValue = 0.0F;

        public static float DpiScalingValue
        {
            get { return _dpiScalingValue == 0.0F ? 1 : _dpiScalingValue; }
            set { _dpiScalingValue = value; }
        }
        

        public static float PrimaryDpiScalingValue = 0.0F;

        public static bool StartedOnPrimaryScreen = true;

        public static ConcurrentDictionary<Control, bool> ScalingDictionary = new ConcurrentDictionary<Control, bool>();

        public static Form MainForm { get; set; }

        static ResizeUtil()
        {
        }

        public static void Initialize(Form mainForm)
        {
            MainForm = mainForm;
            PrimaryDpiScalingValue = (float)DPIUtil.PrimaryScaleFactor(MainForm) / 100;
            if (!System.Windows.Forms.Screen.FromControl(MainForm).Primary)
            {
                StartedOnPrimaryScreen = false;

                if (_dpiScalingValue == 0.0F)
                    _dpiScalingValue = (float)DPIUtil.ScaleFactor(MainForm, MainForm.Location) / 100;
            }
        }

        public static void ScaleForPrimaryScreen(ControlCollection controls, bool scaleProcessLibrary = true)
        {
            foreach (Control controlToAdd in controls)
            {
                if (controlToAdd is ToolStrip)
                {
                    var toolStrip = (ToolStrip)controlToAdd;
                    toolStrip.ImageScalingSize = new System.Drawing.Size((int)(toolStrip.ImageScalingSize.Width * DpiScalingValue), (int)(toolStrip.ImageScalingSize.Height * DpiScalingValue));
                    ScaleToolStripItem(toolStrip.Items, DpiScalingValue, toolStrip, false);
                }
                else
                {
                    if(controlToAdd is TreeView)
                    {
                        ScaleControl(controlToAdd, DpiScalingValue, null, scaleProcessLibrary, false, false, false);
                    }
                    else if (controlToAdd is ESBResizableCheckBox)
                    {
                        var checkBox = controlToAdd as ESBResizableCheckBox;
                        checkBox.TextLocationX += (int)(5 * DpiScalingValue);
                        checkBox.TickTopPosition -= (int)(2 * DpiScalingValue);
                    }
                    else if (!(controlToAdd is ElementHost) && !(controlToAdd is PropertyGrid))
                    {
                        ScaleControl(controlToAdd, DpiScalingValue, null, true, false, false, false);
                    }

                    if(controlToAdd is TabControl)
                    {
                        var tabControl = controlToAdd as TabControl;
                        tabControl.ItemSize = new System.Drawing.Size((int)(tabControl.ItemSize.Width), (int)(tabControl.ItemSize.Height * DpiScalingValue));
                    }
                }
                if (controlToAdd.HasChildren)
                {
                    ScaleForPrimaryScreen(controlToAdd.Controls);
                }
            }
        }

        public static void CreateScalingDictionary(ControlCollection controls, Dictionary<Control, bool> controlDictionary, Dictionary<Control, bool> tabControlDictionary)
        {
            foreach (Control controlToAdd in controls)
            {
                if (controlToAdd is TabControl)
                {
                    tabControlDictionary.Add(controlToAdd, false);
                    CreateTabControlScalingDictionary(controlToAdd.Controls, tabControlDictionary);
                }
                else
                {
                    controlDictionary.Add(controlToAdd, false);
                    if (controlToAdd.HasChildren)
                    {
                        CreateScalingDictionary(controlToAdd.Controls, controlDictionary, tabControlDictionary);
                    }
                }
            }
        }

        public static void CreateTabControlScalingDictionary(ControlCollection controls, Dictionary<Control, bool> tabControlDictionary)
        {
            foreach (Control controlToAdd in controls)
            {
                tabControlDictionary.Add(controlToAdd, false);
                if (controlToAdd.HasChildren)
                {
                    CreateTabControlScalingDictionary(controlToAdd.Controls, tabControlDictionary);
                }
            }
        }

        public static void ScaleFormChildren(float dpiScale, Dictionary<Control, bool> scalingDictionary, Dictionary<Control, bool> tabControlScalingDictionary, Form containingForm, bool scaleTreeView = true)
        {

            for (int i = 0; i < scalingDictionary.Count; i++)
            {
                if (!scalingDictionary.ElementAt(i).Value)
                {
                    if (scalingDictionary.ElementAt(i).Key != null)
                    {
                        Font parentFont = null;
                        if (scalingDictionary.ElementAt(i).Key.Parent != null && scalingDictionary.ElementAt(i).Key.Parent.Font != null)
                        {
                            parentFont = scalingDictionary.ElementAt(i).Key.Parent.Font;
                        }
                        ScaleControl(scalingDictionary.ElementAt(i).Key, dpiScale, containingForm, scaleTreeView);
                        scalingDictionary[scalingDictionary.ElementAt(i).Key] = true;
                    }
                }
            }
            for (int i = 0; i < tabControlScalingDictionary.Count; i++)
            {
                if (!tabControlScalingDictionary.ElementAt(i).Value)
                {
                    if (tabControlScalingDictionary.ElementAt(i).Key != null)
                    {
                        Font parentFont = null;
                        if (tabControlScalingDictionary.ElementAt(i).Key.Parent != null && tabControlScalingDictionary.ElementAt(i).Key.Parent.Font != null)
                        {
                            parentFont = tabControlScalingDictionary.ElementAt(i).Key.Parent.Font;
                        }
                        ScaleTabControl(tabControlScalingDictionary.ElementAt(i).Key, dpiScale, containingForm);
                        tabControlScalingDictionary[tabControlScalingDictionary.ElementAt(i).Key] = true;
                    }
                }
            }
        }

        public static void ScaleAll(Form formToScale, bool scaleTreeView = true)
        {
            var primaryDpi = DPIUtil.GetDpi(formToScale, new Point(0, 0));
            if (StartedOnPrimaryScreen || (_dpiScalingValue == 1.0F && primaryDpi != 96))
            {
                if ((_dpiScalingValue == 1.0F && primaryDpi != 96) || (primaryDpi != 96 && StartedOnPrimaryScreen))
                {
                    if (_dpiScalingValue == 0.0F)
                        DpiScalingValue = (float)DPIUtil.ScaleFactor(formToScale, formToScale.Location) / 100;

                    Dictionary<Control, bool> scalingDictionary = new Dictionary<Control, bool>();
                    Dictionary<Control, bool> tabControlScalingDictionary = new Dictionary<Control, bool>();
                    scalingDictionary.Add(formToScale, false);
                    CreateScalingDictionary(formToScale.Controls, scalingDictionary, tabControlScalingDictionary);
                    foreach(Control control in scalingDictionary.Keys)
                    {
                        if(control is ESBResizableCheckBox)
                        {
                            var checkbox = (ESBResizableCheckBox)control;
                            ResizeCheckbox(checkbox);
                        }
                    }
                    foreach (Control control in tabControlScalingDictionary.Keys)
                    {
                        if (control is ESBResizableCheckBox)
                        {
                            var checkbox = (ESBResizableCheckBox)control;
                            ResizeCheckbox(checkbox);
                        }
                    }

                }
                if (StartedOnPrimaryScreen && primaryDpi != 96)
                {
                    ScaleForPrimaryScreen(formToScale.Controls);
                    return;
                }
                else if(StartedOnPrimaryScreen)
                {
                    return;
                }
            }

            if (formToScale != null)
            {
                if (_dpiScalingValue == 0.0F)
                    DpiScalingValue = (float)DPIUtil.ScaleFactor(formToScale, formToScale.Location) / 100;

                if (_dpiScalingValue != 1.0F)
                {
                    Dictionary<Control, bool> scalingDictionary = new Dictionary<Control, bool>();
                    Dictionary<Control, bool> tabControlScalingDictionary = new Dictionary<Control, bool>();
                    scalingDictionary.Add(formToScale, false);
                    CreateScalingDictionary(formToScale.Controls, scalingDictionary, tabControlScalingDictionary);
                    ScaleFormChildren(DpiScalingValue, scalingDictionary, tabControlScalingDictionary, formToScale, scaleTreeView);
                }
            }
        }

        public static void ScaleAll(UserControl formToScale, bool scaleTreeView = true)
        {
            if (StartedOnPrimaryScreen)
            {
                return;
            }

            if (formToScale != null)
            {
                if (_dpiScalingValue == 0.0F)
                    DpiScalingValue = (float)DPIUtil.ScaleFactor(formToScale, formToScale.Location) / 100;

                if (_dpiScalingValue != 1.0F)
                {
                    Dictionary<Control, bool> scalingDictionary = new Dictionary<Control, bool>();
                    Dictionary<Control, bool> tabControlScalingDictionary = new Dictionary<Control, bool>();
                    scalingDictionary.Add(formToScale, false);
                    CreateScalingDictionary(formToScale.Controls, scalingDictionary, tabControlScalingDictionary);
                    ScaleFormChildren(DpiScalingValue, scalingDictionary, tabControlScalingDictionary, null, scaleTreeView);
                }
            }
        }

        public static void ScaleToolStripItem(ToolStripItemCollection items, float dpiScale, ToolStrip parent, bool scaleFont = true)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripSeparator)
                {
                    item.Size = new System.Drawing.Size((int)Math.Round(item.Size.Width * dpiScale), (int)Math.Round(item.Size.Height * dpiScale));
                }

                if (!(item is ToolStripComboBox) && scaleFont)
                {
                    var fontSize = item.Font.Size * dpiScale;
                    item.Font = new Font(item.Font.FontFamily.Name, fontSize, item.Font.Style, item.Font.Unit, item.Font.GdiCharSet);
                }
                else
                {
                }
                if (item is ToolStripButton)
                {
                    var button = (ToolStripButton)item;
                    if (button.BackgroundImage != null)
                        button.BackgroundImage = ResizeImage(button.BackgroundImage, (int)Math.Round(button.BackgroundImage.Size.Width * dpiScale), (int)Math.Round(button.BackgroundImage.Size.Height * dpiScale));
                    if (button.Image != null)
                        button.Image = ResizeImage(button.Image, (int)Math.Round(button.Image.Size.Width * dpiScale), (int)Math.Round(button.Image.Size.Height * dpiScale));
                }

                if (item is ToolStripDropDownButton)
                {
                    var button = (ToolStripDropDownButton)item;
                    if (button.Image != null)
                        button.Image = ResizeImage(button.Image, (int)Math.Round(button.Image.Size.Width * dpiScale), (int)Math.Round(button.Image.Size.Height * dpiScale));
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1">Neuron.Explorer.UserControls.ESBResizableCheckBox or object</typeparam>
        /// <typeparam name="T2">Neuron.Explorer.FormPipelineLibrary</typeparam>
        /// <typeparam name="T3">PipelineStepsTab</typeparam>
        /// <param name="control"></param>
        /// <param name="dpiScale"></param>
        /// <param name="containingForm"></param>
        public static void ScaleControl(Control control, float dpiScale, Form containingForm, bool scaleTreeView = true, bool doubleScaleCheckbox = true, bool scaleTreeViewFont = true, bool scaleFont = true, bool scaleProcessLibraryTvHeight = true)
        {
            var dpiScaleF = new SizeF(dpiScale, dpiScale);
            if (control.Parent != null && scaleFont)
                scaleFont = control.Parent.Font != control.Font;

            if (control is Form)
            {
                var formControl = (control as Form);
                formControl.Scale(dpiScaleF);

                var formFontSize = formControl.Font.Size * dpiScale;
                formControl.Font = new Font(formControl.Font.FontFamily.Name, formFontSize, formControl.Font.Style, formControl.Font.Unit, formControl.Font.GdiCharSet);
                scaleFont = false;
            }
            else if (!(control is ToolStrip))
            {
                if (control is Panel)
                {
                    var panelControl = control as Panel;
                    if (panelControl.BackgroundImage != null)
                        panelControl.BackgroundImage = ResizeImage(panelControl.BackgroundImage, (int)(panelControl.BackgroundImage.Width * dpiScale), (int)(panelControl.BackgroundImage.Height * dpiScale));
                }
                if (control is PictureBox)
                {
                    var picControl = control as PictureBox;

                    if (picControl.Image != null)
                        picControl.Image = ResizeImage(picControl.Image, (int)(picControl.Image.Width * dpiScale), (int)(picControl.Image.Height * dpiScale));

                    if (picControl.BackgroundImage != null)
                        picControl.BackgroundImage = ResizeImage(picControl.BackgroundImage, (int)(picControl.BackgroundImage.Width * dpiScale), (int)(picControl.BackgroundImage.Height * dpiScale));
                }
            }

            if (control is ToolStrip)
            {
                var toolStripControl = control as ToolStrip;
                if (toolStripControl.GripDisplayStyle == ToolStripGripDisplayStyle.Horizontal)
                {
                    toolStripControl.GripMargin = new Padding((int)(toolStripControl.GripMargin.Left * dpiScale), toolStripControl.GripMargin.Top, toolStripControl.GripMargin.Right, toolStripControl.GripMargin.Bottom);
                }

                if (!(control is ToolStripDropDown))
                    toolStripControl.ImageScalingSize = new System.Drawing.Size((int)(toolStripControl.ImageScalingSize.Width * dpiScale), (int)(toolStripControl.ImageScalingSize.Height * dpiScale));
                ScaleToolStripItem(toolStripControl.Items, dpiScale, toolStripControl);
                return;
            }

            if (scaleFont)
            {
                var fontSize = control.Font.Size * dpiScale;
                control.Font = new Font(control.Font.FontFamily.Name, fontSize, control.Font.Style, control.Font.Unit, control.Font.GdiCharSet);
            }

            if (control is ListView || control is DataGridView
                || control is TreeView //|| control is PropertyGrid || control is ComboBox
                 || control is TabControl || control is RadioButton
                || control is Label || control is Button
                || control is CheckBox || control is TextBox)
            {
                if (!(control is CheckBox) && scaleFont)
                {
                    //var fontSize = control.Font.Size * dpiScale;
                    //control.Font = new Font(control.Font.FontFamily.Name, fontSize, control.Font.Style, control.Font.Unit, control.Font.GdiCharSet);
                }
                else
                {
                    if (control is Neuron.Explorer.UserControls.ESBResizableCheckBox)
                    {
                        var checkbox = control as Neuron.Explorer.UserControls.ESBResizableCheckBox;
                        var primaryDpiScaling = PrimaryDpiScalingValue == 1.0F || (PrimaryDpiScalingValue > 1.0F && !StartedOnPrimaryScreen) ? PrimaryDpiScalingValue : DpiScalingValue * PrimaryDpiScalingValue * 2;

                        checkbox.TickSize *= dpiScale;
                        if(_dpiScalingValue > 1.0F)
                        {
                            checkbox.TickLeftPosition -= (dpiScale * primaryDpiScaling * (checkbox.TickLeftPosition + dpiScale) + 2);
                            checkbox.TickTopPosition -= dpiScale * primaryDpiScaling * (dpiScale + 1) + 1;
                        }
                        
                        checkbox.BoxSize = (int)(checkbox.BoxSize * dpiScale);
                        checkbox.BoxLocationY += (int)(((dpiScale) / 2));
                        checkbox.BoxLocationX += (int)((dpiScale / 2));

                        checkbox.TextLocationY = (int)(checkbox.TextLocationY - dpiScale);
                        if (doubleScaleCheckbox)
                        {
                            checkbox.TextLocationX = (int)(checkbox.TextLocationX + checkbox.BoxSize - dpiScale);
                        }

                        if (dpiScale != 1.0F && doubleScaleCheckbox)
                            ResizeCheckbox(checkbox);
                    }
                }

                if (control is TreeView)
                {
                    TreeView treeView = control as TreeView;
                    if (control.Parent != null)
                    {
                        if (!(control.Parent is PipelineStepsTab) && treeView.ImageList != null)
                        {
                            ImageList imgCol = new ImageList();
                            for (int i = 0; i < treeView.ImageList.Images.Count; i++)
                            {
                                imgCol.Images.Add(treeView.ImageList.Images.Keys[i], ResizeImage(treeView.ImageList.Images[i], (int)(treeView.ImageList.Images[i].Width * dpiScale), (int)(treeView.ImageList.Images[i].Height * dpiScale)));
                            }

                            imgCol.ImageSize = new System.Drawing.Size((int)(treeView.ImageList.ImageSize.Width * dpiScale), (int)(treeView.ImageList.ImageSize.Height * dpiScale));
                            treeView.ImageList = imgCol;
                            if(scaleTreeView)
                                treeView.ItemHeight = (int)(treeView.ItemHeight * dpiScale);
                        }
                        else if (control.Parent is PipelineStepsTab && treeView.ImageList != null)
                        {
                            ImageList imgCol = new ImageList();
                            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipelineStepsTab));
                            imgCol.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stepImageList.ImageStream")));
                            imgCol.Images.SetKeyName(0, "book.png");
                            imgCol.Images.SetKeyName(1, "package.png");
                            imgCol.Images.SetKeyName(2, "folder.png");
                            imgCol.Images.SetKeyName(3, "folder_closed.png");
                            imgCol.Images.SetKeyName(4, "folder_closed_add.png");
                            imgCol.Images.SetKeyName(5, "document-open-folder.png");
                            imgCol.Images.SetKeyName(6, "folder1.png");
                            imgCol.Images.SetKeyName(7, "folder-new-7.png");
                            treeView.ImageList.ImageSize = new System.Drawing.Size((int)(treeView.ImageList.ImageSize.Width * dpiScale), (int)(treeView.ImageList.ImageSize.Height * dpiScale));
                            for (int i = 0; i < imgCol.Images.Count; i++)
                            {
                                treeView.ImageList.Images.Add(ResizeImage(imgCol.Images[i], (int)(imgCol.Images[i].Width * dpiScale), (int)(imgCol.Images[i].Height * dpiScale)));
                                treeView.ImageList.Images.SetKeyName(i, imgCol.Images.Keys[i]);
                            }

                            treeView.ItemHeight = (int)(treeView.ItemHeight * dpiScale);
                            foreach (TreeNode treeNode in treeView.Nodes)
                            {
                                if (scaleTreeViewFont)
                                {
                                    var fontSize1 = treeNode.NodeFont.Size * dpiScale;
                                    treeNode.NodeFont = new Font(treeNode.NodeFont.FontFamily.Name, fontSize1, treeNode.NodeFont.Style, treeNode.NodeFont.Unit, treeNode.NodeFont.GdiCharSet);
                                }
                            }
                            return;
                        }
                    }

                    foreach (TreeNode treeNode in treeView.Nodes)
                    {
                        foreach (TreeNode secondTreeNodes in treeNode.Nodes)
                        {
                            if (secondTreeNodes.NodeFont != null && scaleTreeViewFont)
                            {
                                var fontSize1 = secondTreeNodes.NodeFont.Size * dpiScale;
                                secondTreeNodes.NodeFont = new Font(secondTreeNodes.NodeFont.FontFamily.Name, fontSize1, secondTreeNodes.NodeFont.Style, secondTreeNodes.NodeFont.Unit, secondTreeNodes.NodeFont.GdiCharSet);
                            }
                        }
                    }
                }

                if (control is Label)
                {
                    var label = control as Label;
                    if (label.Image != null)
                    {
                        label.Image = ResizeImage(label.Image, (int)(label.Image.Width * dpiScale), (int)(label.Image.Height * dpiScale));
                    }
                }
            }
        }

        public static void ScaleTabControl(Control control, float dpiScale, Form containingForm)
        {
            var dpiScaleF = new SizeF(dpiScale, dpiScale);
            bool scaleFont = true;
            if (control.Parent != null)
                scaleFont = control.Parent.Font != control.Font;

            if (control is PropertyGrid)
            {
                var propertyGrid = control as PropertyGrid;
            }
            if (control is Form)
            {
                var formControl = (control as Form);
                formControl.Scale(dpiScaleF);

                var formFontSize = formControl.Font.Size * dpiScale;
                formControl.Font = new Font(formControl.Font.FontFamily.Name, formFontSize, formControl.Font.Style, formControl.Font.Unit, formControl.Font.GdiCharSet);
                scaleFont = false;
            }
            else if (!(control is ToolStrip))
            {
                if (control is Panel)
                {
                    var panelControl = control as Panel;
                    if (panelControl.BackgroundImage != null)
                        panelControl.BackgroundImage = ResizeImage(panelControl.BackgroundImage, (int)(panelControl.BackgroundImage.Width * dpiScale), (int)(panelControl.BackgroundImage.Height * dpiScale));
                }
                if (control is PictureBox)
                {
                    var picControl = control as PictureBox;
                    if (picControl.Image != null)
                        picControl.Image = ResizeImage(picControl.Image, (int)(picControl.Image.Width * dpiScale), (int)(picControl.Image.Height * dpiScale));

                    if (picControl.BackgroundImage != null)
                        picControl.BackgroundImage = ResizeImage(picControl.BackgroundImage, (int)(picControl.BackgroundImage.Width * dpiScale), (int)(picControl.BackgroundImage.Height * dpiScale));
                }
            }

            if (control is ToolStrip)
            {
                var toolStripControl = control as ToolStrip;
                if (toolStripControl.GripDisplayStyle == ToolStripGripDisplayStyle.Horizontal)
                {
                    toolStripControl.GripMargin = new Padding((int)(toolStripControl.GripMargin.Left * dpiScale), toolStripControl.GripMargin.Top, toolStripControl.GripMargin.Right, toolStripControl.GripMargin.Bottom);
                }

                if (!(control is ToolStripDropDown))
                    toolStripControl.ImageScalingSize = new System.Drawing.Size((int)(toolStripControl.ImageScalingSize.Width * dpiScale), (int)(toolStripControl.ImageScalingSize.Height * dpiScale));
                ScaleToolStripItem(toolStripControl.Items, dpiScale, toolStripControl);
                return;
            }

            if (scaleFont && ((control is Label) || (control is PropertyGrid) || (control is DataGridView) || (control is GroupBox)
                || (control is ListBox || (control is RadioButton) || (control is ComboBox) || (control is NumericUpDown))))
            {
                var fontSize = control.Font.Size * dpiScale;
                control.Font = new Font(control.Font.FontFamily.Name, fontSize, control.Font.Style, control.Font.Unit, control.Font.GdiCharSet);
                if ((control is Label) && control.AutoSize != true)
                {
                    control.Height = (int)Math.Round(control.Height * dpiScale);
                    control.Width = (int)Math.Round(control.Width * dpiScale);
                }
            }

            if ((control is TreeView || control is DataGridView//|| control is ComboBox || control is ListView || control is DataGridView || control is TextBox
                || control is RadioButton
                || control is Label || control is Button
                || control is CheckBox))
            {
                if (!(control is CheckBox) && !(control is UserControls.ESBResizableCheckBox) && scaleFont)
                {
                    //var fontSize = control.Font.Size * dpiScale;
                    //control.Font = new Font(control.Font.FontFamily.Name, fontSize, control.Font.Style, control.Font.Unit, control.Font.GdiCharSet);
                }
                else
                {
                    if (control is Neuron.Explorer.UserControls.ESBResizableCheckBox)
                    {
                        var checkbox = control as Neuron.Explorer.UserControls.ESBResizableCheckBox;
                        var fontSize = checkbox.Font.Size * dpiScale;
                        var primaryDpiScaling = PrimaryDpiScalingValue == 1.0F || (PrimaryDpiScalingValue > 1.0F && !StartedOnPrimaryScreen) ? PrimaryDpiScalingValue : DpiScalingValue * PrimaryDpiScalingValue * 2;
                        checkbox.TickSize *= dpiScale;

                        if (_dpiScalingValue > 1.0F)
                        {
                            checkbox.TickLeftPosition -= (dpiScale * primaryDpiScaling * (checkbox.TickLeftPosition + dpiScale) + 2);
                            checkbox.TickTopPosition -= dpiScale * primaryDpiScaling * (dpiScale + 1) + 1;
                        }

                        checkbox.BoxSize = (int)(checkbox.BoxSize * dpiScale);
                        if (scaleFont)
                            checkbox.Font = new Font(checkbox.Font.FontFamily.Name, fontSize, checkbox.Font.Style, checkbox.Font.Unit, checkbox.Font.GdiCharSet);

                        checkbox.BoxLocationY += (int)(((dpiScale) / 2));
                        checkbox.BoxLocationX += (int)((dpiScale / 2));
                        checkbox.TextLocationX = (int)(checkbox.TextLocationX + checkbox.BoxSize - dpiScale);
                        checkbox.TextLocationY = (int)(checkbox.TextLocationY - dpiScale);

                        if (dpiScale != 1.0F)
                            ResizeCheckbox(checkbox);
                    }
                }

                if (control is TreeView)
                {
                    TreeView treeView = control as TreeView;
                    treeView.ItemHeight = (int)(treeView.ItemHeight * dpiScale);

                    if(treeView.ImageList != null)
                    {
                        ImageList imgCol = new ImageList();
                        for (int i = 0; i < treeView.ImageList.Images.Count; i++)
                        {
                            imgCol.Images.Add(treeView.ImageList.Images.Keys[i], ResizeImage(treeView.ImageList.Images[i], (int)(treeView.ImageList.Images[i].Width * dpiScale), (int)(treeView.ImageList.Images[i].Height * dpiScale)));
                        }

                        imgCol.ImageSize = new System.Drawing.Size((int)(treeView.ImageList.ImageSize.Width * dpiScale), (int)(treeView.ImageList.ImageSize.Height * dpiScale));
                        treeView.ImageList = imgCol;
                    }
                    
                    foreach (TreeNode treeNode in treeView.Nodes)
                    {
                        foreach (TreeNode secondTreeNodes in treeNode.Nodes)
                        {
                            if (secondTreeNodes.NodeFont != null)
                            {
                                var fontSize1 = secondTreeNodes.NodeFont.Size * dpiScale;
                                secondTreeNodes.NodeFont = new Font(secondTreeNodes.NodeFont.FontFamily.Name, fontSize1, secondTreeNodes.NodeFont.Style, secondTreeNodes.NodeFont.Unit, secondTreeNodes.NodeFont.GdiCharSet);
                            }
                        }
                    }
                }

                if (control is Label)
                {
                    var label = control as Label;
                    if (label.Image != null)
                    {
                        label.Image = ResizeImage(label.Image, (int)(label.Image.Width * dpiScale), (int)(label.Image.Height * dpiScale));
                    }
                }
            }
            if (control is TabControl)
            {
                var tabControl = control as TabControl;
                var fontSize = tabControl.Font.Size * dpiScale;
                tabControl.Font = new Font(tabControl.Font.FontFamily.Name, fontSize, tabControl.Font.Style, tabControl.Font.Unit, tabControl.Font.GdiCharSet);
                tabControl.ItemSize = new Size((int)(tabControl.ItemSize.Width * dpiScale), (int)(tabControl.ItemSize.Height * dpiScale));
            }
        }

        public static Bitmap ResizeImage(Image image, float scalingValue)
        {
            if (scalingValue == 1.0F)
                return (Bitmap)image;
            else
                return ResizeImage(image, (int)(image.Width * scalingValue), (int)(image.Height * scalingValue));
        }


        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static void ResizeCheckbox(ESBResizableCheckBox checkBox)
        {
            var dpiPrimary = DPIUtil.GetDpi(checkBox, new Point(0, 0));
            if (dpiPrimary != 96)
            {
                checkBox.BoxSize = (int)(checkBox.BoxSize * (dpiPrimary / 96.0F));
                checkBox.TextLocationX += (int)(DpiScalingValue + (4 * dpiPrimary / 96.0F));
                checkBox.TickLeftPosition -= 2 * (dpiPrimary / 96.0F);
                checkBox.TickTopPosition -= 2 * (dpiPrimary / 96.0F);
            }
        }
    }


    public static class DPIUtil
    {
        /// <summary>
        /// Min OS version build that supports DPI per monitor
        /// </summary>
        private const int MinOSVersionBuild = 14393;

        /// <summary>
        /// Min OS version major build that support DPI per monitor
        /// </summary>
        private const int MinOSVersionMajor = 10;

        /// <summary>
        /// Flag, if OS supports DPI per monitor
        /// </summary>
        private static bool _isSupportingDpiPerMonitor;

        /// <summary>
        /// Flag, if OS version checked
        /// </summary>
        private static bool _isOSVersionChecked;

        /// <summary>
        /// Flag, if OS supports DPI per monitor
        /// </summary>
        internal static bool IsSupportingDpiPerMonitor
        {
            get
            {
                if (_isOSVersionChecked)
                {
                    return _isSupportingDpiPerMonitor;
                }

                _isOSVersionChecked = true;
                var osVersionInfo = new OSVERSIONINFOEXW
                {
                    dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEXW))
                };

                if (RtlGetVersion(ref osVersionInfo) != 0)
                {
                    _isSupportingDpiPerMonitor = Environment.OSVersion.Version.Major >= MinOSVersionMajor && Environment.OSVersion.Version.Build >= MinOSVersionBuild;

                    return _isSupportingDpiPerMonitor;
                }

                _isSupportingDpiPerMonitor = osVersionInfo.dwMajorVersion >= MinOSVersionMajor && osVersionInfo.dwBuildNumber >= MinOSVersionBuild;

                return _isSupportingDpiPerMonitor;
            }
        }

        /// <summary>
        /// Get scale factor for primary monitor
        /// </summary>
        /// <param name="control"> Any control for OS who doesn't support DPI per monitor </param>
        /// <param name="monitorPoint"> Monitor point (Screen.Bounds) </param>
        /// <returns> Scale factor </returns>
        public static double PrimaryScaleFactor(Control control)
        {
            float primaryMonitorDpi = GetDpi(control, new Point(0, 0));
            return primaryMonitorDpi * 100 / 96.0F;
        }

        /// <summary>
        /// Get scale factor for an each monitor
        /// </summary>
        /// <param name="control"> Any control for OS who doesn't support DPI per monitor </param>
        /// <param name="monitorPoint"> Monitor point (Screen.Bounds) </param>
        /// <returns> Scale factor </returns>
        public static double ScaleFactor(Control control, Point monitorPoint)
        {
            var dpi = GetDpi(control, monitorPoint);
            float primaryMonitorDpi = GetDpi(control, new Point(0, 0));
            if (System.Windows.Forms.Screen.FromControl(control).Primary)
            {
                return dpi * 100 / 96.0F;
            }
            return dpi * 100 / primaryMonitorDpi;
        }

        /// <summary>
        /// Get DPI for a monitor
        /// </summary>
        /// <param name="control"> Any control for OS who doesn't support DPI per monitor </param>
        /// <param name="monitorPoint"> Monitor point (Screen.Bounds) </param>
        /// <returns> DPI </returns>
        public static uint GetDpi(Control control, Point monitorPoint)
        {
            uint dpiX;

            if (IsSupportingDpiPerMonitor)
            {
                var monitorFromPoint = MonitorFromPoint(monitorPoint, 2);

                GetDpiForMonitor(monitorFromPoint, DpiType.Effective, out dpiX, out _);
            }
            else
            {
                // If using with System.Windows.Forms - can be used Control.DeviceDpi
                dpiX = control == null ? 96 : (uint)control.DeviceDpi;
            }

            return dpiX;
        }

        /// <summary>
        /// Retrieves a handle to the display monitor that contains a specified point.
        /// </summary>
        /// <param name="pt"> Specifies the point of interest in virtual-screen coordinates. </param>
        /// <param name="dwFlags"> Determines the function's return value if the point is not contained within any display monitor. </param>
        /// <returns> If the point is contained by a display monitor, the return value is an HMONITOR handle to that display monitor. </returns>
        /// <remarks>
        /// <see cref="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-monitorfrompoint"/>
        /// </remarks>
        [DllImport("User32.dll")]
        internal static extern IntPtr MonitorFromPoint([In] Point pt, [In] uint dwFlags);

        /// <summary>
        /// Queries the dots per inch (dpi) of a display.
        /// </summary>
        /// <param name="hmonitor"> Handle of the monitor being queried. </param>
        /// <param name="dpiType"> The type of DPI being queried. </param>
        /// <param name="dpiX"> The value of the DPI along the X axis. </param>
        /// <param name="dpiY"> The value of the DPI along the Y axis. </param>
        /// <returns> Status success </returns>
        /// <remarks>
        /// <see cref="https://learn.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getdpiformonitor"/>
        /// </remarks>
        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);

        /// <summary>
        /// The RtlGetVersion routine returns version information about the currently running operating system.
        /// </summary>
        /// <param name="versionInfo"> Operating system version information </param>
        /// <returns> Status success</returns>
        /// <remarks>
        /// <see cref="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlgetversion"/>
        /// </remarks>
        [SecurityCritical]
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int RtlGetVersion(ref OSVERSIONINFOEXW versionInfo);

        /// <summary>
        /// Contains operating system version information.
        /// </summary>
        /// <remarks>
        /// <see cref="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw"/>
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        private struct OSVERSIONINFOEXW
        {
            /// <summary>
            /// The size of this data structure, in bytes
            /// </summary>
            internal int dwOSVersionInfoSize;

            /// <summary>
            /// The major version number of the operating system.
            /// </summary>
            internal int dwMajorVersion;

            /// <summary>
            /// The minor version number of the operating system.
            /// </summary>
            internal int dwMinorVersion;

            /// <summary>
            /// The build number of the operating system.
            /// </summary>
            internal int dwBuildNumber;

            /// <summary>
            /// The operating system platform.
            /// </summary>
            internal int dwPlatformId;

            /// <summary>
            /// A null-terminated string, such as "Service Pack 3", that indicates the latest Service Pack installed on the system.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string szCSDVersion;

            /// <summary>
            /// The major version number of the latest Service Pack installed on the system. 
            /// </summary>
            internal ushort wServicePackMajor;

            /// <summary>
            /// The minor version number of the latest Service Pack installed on the system.
            /// </summary>
            internal ushort wServicePackMinor;

            /// <summary>
            /// A bit mask that identifies the product suites available on the system. 
            /// </summary>
            internal short wSuiteMask;

            /// <summary>
            /// Any additional information about the system.
            /// </summary>
            internal byte wProductType;

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            internal byte wReserved;
        }

        /// <summary>
        /// DPI type
        /// </summary>
        /// <remarks>
        /// <see cref="https://learn.microsoft.com/en-us/windows/win32/api/shellscalingapi/ne-shellscalingapi-monitor_dpi_type"/>
        /// </remarks>
        private enum DpiType
        {
            /// <summary>
            /// The effective DPI. This value should be used when determining the correct scale factor for scaling UI elements.
            /// </summary>
            Effective = 0,

            /// <summary>
            /// The angular DPI. This DPI ensures rendering at a compliant angular resolution on the screen.
            /// </summary>
            Angular = 1,

            /// <summary>
            /// The raw DPI. This value is the linear DPI of the screen as measured on the screen itself. Use this value when you want to read the pixel density and not the recommended scaling setting.
            /// </summary>
            Raw = 2,
        }
    }
}
