using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Neuron.Pipelines.Design
{
    using System.Drawing;
    using System.Runtime.InteropServices;

    public partial class PipelineStepsTab : UserControl
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public PipelineStepsTab()
        {
            InitializeComponent();

            Options = new List<PipelineStepOption>();
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            SendMessage(textBox1.Handle, 0x1501, 1, "Search Steps");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.tvSteps.BeginUpdate();
            this.tvSteps.Nodes.Clear();
            var top = new TreeNode
            {
                Text = "Process Steps",
                ImageIndex = 3,
                SelectedImageIndex = 3,
                Tag = "TOP"
            };
            top.ContextMenuStrip = new ContextMenuStrip();
            top.ContextMenuStrip.Items.AddRange(
                new ToolStripMenuItem[]
                    {
                        new ToolStripMenuItem(
                            "Collapse All",
                            null,
                            (s, args) =>
                                {
                                    foreach (TreeNode node in top.Nodes)
                                    {
                                        node.Collapse(false);
                                    }

                                    top.EnsureVisible();
                                }),
                        new ToolStripMenuItem(
                            "Expand All",
                            null,
                            (s, args) =>
                                {
                                    top.ExpandAll();
                                    top.EnsureVisible();
                                })
                    });
            tvSteps.Nodes.Add(top);
            Options.Sort(
                    (p1, p2) =>
                    {
                        if (p1 == null && p2 == null)
                        {
                            return 0;
                        }
                        else if (p1 == null)
                        {
                            return -1;
                        }
                        else if (p2 == null)
                        {
                            return 1;
                        }

                        if (!string.IsNullOrEmpty(p1.Path) && !string.IsNullOrEmpty(p2.Path))
                        {
                            int result;

                            result = p1.Path.CompareTo(p2.Path);
                            if (0 == result)
                            {
                                if (!string.IsNullOrEmpty(p1.Name) && !string.IsNullOrEmpty(p2.Name))
                                    result = p1.Name.CompareTo(p2.Name);
                            }

                            return result;
                        }
                        else if (null == p1.Path)
                        {
                            return -1;
                        }
                        else if(null == p2.Path)
                        {
                            return 1;
                        }

                        return 0;
                    });
          
            foreach (var option in Options.Where(r => r.Name.ToLower().Contains(textBox1.Text.ToLower())))
            {
                if (!string.IsNullOrEmpty(option.Path))
                {
                    var sep = string.Empty;
                    // get the seperator
                    if (option.Path.Contains("/"))
                    {
                        sep = "/";
                    }
                    else if (option.Path.Contains(@"\"))
                    {
                        sep = @"\";
                    }

                    if (string.IsNullOrEmpty(sep)) // only 1 folder
                    {
                        var rootNode = top.Nodes.Cast<TreeNode>().ToList().Find(n => n.Text.Equals(option.Path));
                        if (rootNode != null)
                        {
                            stepImageList.Images.Add(option.Image);
                            var index = stepImageList.Images.Count - 1;
                            rootNode.Nodes.Add(
                                new TreeNode(option.Name)
                                {
                                    ImageIndex = index,
                                    SelectedImageIndex = index,
                                    Tag = option,
                                    ToolTipText = option.Description
                                });
                        }
                        else
                        {
                            var fldNode = new TreeNode(option.Path)
                            {
                                ImageIndex = 3,
                                SelectedImageIndex = 3,
                                Tag = "TOP",
                                ToolTipText = option.Path
                            };
                            stepImageList.Images.Add(option.Image);
                            var index = stepImageList.Images.Count - 1;
                            fldNode.Nodes.Add(
                                new TreeNode(option.Name)
                                {
                                    ImageIndex = index,
                                    SelectedImageIndex = index,
                                    Tag = option,
                                    ToolTipText = option.Description
                                });
                            fldNode.Collapse();
                            top.Nodes.Add(fldNode);
                        }
                    }
                    else // folder with sub folders
                    {
                        var paths = option.Path.Split(new[] { sep }, StringSplitOptions.RemoveEmptyEntries);
                        var len = paths.Length;
                        for (var x = 0; x < len; x++)
                        {
                            // find first folder, if found
                            var fld = paths[x];
                            var rootNode = top.Nodes.Cast<TreeNode>().ToList().Find(n => n.Text.Equals(fld));
                            if (rootNode != null)
                            {
                                top = rootNode;
                                // are there any other folders to search for?
                                if (x != len - 1)
                                {
                                    continue;
                                }

                                this.stepImageList.Images.Add(option.Image);
                                var index = this.stepImageList.Images.Count - 1;
                                top.Nodes.Add(
                                    new TreeNode(option.Name)
                                    {
                                        ImageIndex = index,
                                        SelectedImageIndex = index,
                                        Tag = option,
                                        ToolTipText = option.Description
                                    });
                            }
                            else
                            {
                                var fldNode = new TreeNode(fld)
                                {
                                    ImageIndex = 3,
                                    SelectedImageIndex = 3,
                                    Tag = "TOP",
                                    ToolTipText = fld
                                };
                                // are there any other folders to search for?
                                if (x == len - 1) // no..we'e at the end of the loop
                                {
                                    stepImageList.Images.Add(option.Image);
                                    var index = stepImageList.Images.Count - 1;
                                    fldNode.Nodes.Add(
                                        new TreeNode(option.Name)
                                        {
                                            ImageIndex = index,
                                            SelectedImageIndex = index,
                                            Tag = option,
                                            ToolTipText = option.Description
                                        });
                                }

                                fldNode.Collapse();
                                top.Nodes.Add(fldNode);
                                top = fldNode;
                            }
                        }
                    }

                    // restore top
                    top = tvSteps.Nodes[0];
                }
                else
                {
                    stepImageList.Images.Add(option.Image);
                    var index = stepImageList.Images.Count - 1;
                    top.Nodes.Add(
                        new TreeNode(option.Name)
                        {
                            ImageIndex = index,
                            SelectedImageIndex = index,
                            Tag = option,
                            ToolTipText = option.Description,
                        });
                }
            }

            top.ExpandAll();
            top.EnsureVisible();
            this.tvSteps.EndUpdate();
        }

        public List<PipelineStepOption> Options { get; private set; }

        public bool TreeViewLabelEdit
        {
            get { return tvSteps.LabelEdit; }
            set { tvSteps.LabelEdit = value; }
        }

        private void tvSteps_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                e.Node.ImageIndex = 2;
                e.Node.SelectedImageIndex = 2;
            }
            else
            {
                if (e.Node.Tag.ToString() == "TOP")
                {
                    e.Node.ImageIndex = 2;
                    e.Node.SelectedImageIndex = 2;
                }
            }
        }

        private void tvSteps_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                e.Node.ImageIndex = 4;
                e.Node.SelectedImageIndex = 4;
            }
            else
            {
                if (e.Node.Tag.ToString() == "TOP")
                {
                    e.Node.ImageIndex = 3;
                    e.Node.SelectedImageIndex = 3;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tvSteps.Nodes.Clear();
            var top = new TreeNode {
                Text = "Process Steps",
                ImageIndex = 3,
                SelectedImageIndex = 3,
                Tag = "TOP"
            };
            top.ContextMenuStrip = new ContextMenuStrip();
            top.ContextMenuStrip.Items.AddRange(
                new ToolStripMenuItem[]
                    {
                        new ToolStripMenuItem(
                            "Collapse All",
                            null,
                            (s, args) =>
                                {
                                    foreach (TreeNode node in top.Nodes)
                                    {
                                        node.Collapse(false);
                                    }

                                    top.EnsureVisible();
                                }),
                        new ToolStripMenuItem(
                            "Expand All",
                            null,
                            (s, args) =>
                                {
                                    top.ExpandAll();
                                    top.EnsureVisible();
                                })
                    });
            tvSteps.Nodes.Add(top);
            Options.Sort(
                (p1, p2) =>
                    {
                        int result;
                        if (!string.IsNullOrEmpty(p1.Path) && !string.IsNullOrEmpty(p2.Path))
                        {
                            result = p1.Path.CompareTo(p2.Path);
                            if (0 == result)
                            {
                                if (!string.IsNullOrEmpty(p1.Name) && !string.IsNullOrEmpty(p2.Name))
                                {
                                    result = p1.Name.CompareTo(p2.Name);
                                }
                            }
                        }
                        else if (null == p1.Path || p2.Path == null)
                        {
                            result = -1;
                        }
                        else
                        {
                            result = 1;
                        }

                        return result;
                    });
            foreach (var option in Options)
            {
                if (!string.IsNullOrEmpty(option.Path))
                {
                    var sep = string.Empty;
                    // get the seperator
                    if (option.Path.Contains("/"))
                    {
                        sep = "/";
                    }
                    else if (option.Path.Contains(@"\"))
                    {
                        sep = @"\";
                    }

                    if (string.IsNullOrEmpty(sep)) // only 1 folder
                    {
                        var rootNode = top.Nodes.Cast<TreeNode>().ToList().Find(n => n.Text.Equals(option.Path));
                        if (rootNode != null)
                        {
                            stepImageList.Images.Add(option.Image);
                            var index = stepImageList.Images.Count - 1;
                            rootNode.Nodes.Add(
                                new TreeNode(option.Name)
                                    {
                                        ImageIndex = index,
                                        SelectedImageIndex = index,
                                        Tag = option,
                                        ToolTipText = option.Description
                                    });
                        }
                        else
                        {
                            var fldNode = new TreeNode(option.Path)
                                {
                                    ImageIndex = 3,
                                    SelectedImageIndex = 3,
                                    Tag = "TOP",
                                    ToolTipText = option.Path
                                };
                            stepImageList.Images.Add(option.Image);
                            var index = stepImageList.Images.Count - 1;
                            fldNode.Nodes.Add(
                                new TreeNode(option.Name)
                                    {
                                        ImageIndex = index,
                                        SelectedImageIndex = index,
                                        Tag = option,
                                        ToolTipText = option.Description
                                    });
                            fldNode.Collapse();
                            top.Nodes.Add(fldNode);
                        }
                    }
                    else // folder with sub folders
                    {
                        var paths = option.Path.Split(new[] { sep }, StringSplitOptions.RemoveEmptyEntries);
                        var len = paths.Length;
                        for (var x = 0; x < len; x++ )
                        {
                            // find first folder, if found
                            var fld = paths[x];
                            var rootNode = top.Nodes.Cast<TreeNode>().ToList().Find(n => n.Text.Equals(fld));
                            if (rootNode != null)
                            {
                                top = rootNode;
                                // are there any other folders to search for?
                                if (x != len - 1)
                                {
                                    continue;
                                }

                                this.stepImageList.Images.Add(option.Image);
                                var index = this.stepImageList.Images.Count - 1;
                                top.Nodes.Add(
                                    new TreeNode(option.Name)
                                        {
                                            ImageIndex = index,
                                            SelectedImageIndex = index,
                                            Tag = option,
                                            ToolTipText = option.Description
                                        });
                            }
                            else
                            {
                                var fldNode = new TreeNode(fld)
                                    {
                                        ImageIndex = 3,
                                        SelectedImageIndex = 3,
                                        Tag = "TOP",
                                        ToolTipText = fld
                                    };
                                // are there any other folders to search for?
                                if (x == len - 1) // no..we'e at the end of the loop
                                {
                                    if (option.Image == null) throw new Exception(string.Format("The Image could not be found for the '{0}' process step. Unable to display the process step on the canvas.", option.Name));

                                    stepImageList.Images.Add(option.Image);
                                    var index = stepImageList.Images.Count - 1;
                                    fldNode.Nodes.Add(
                                        new TreeNode(option.Name)
                                            {
                                                ImageIndex = index,
                                                SelectedImageIndex = index,
                                                Tag = option,
                                                ToolTipText = option.Description
                                            });
                                }

                                fldNode.Collapse();
                                top.Nodes.Add(fldNode);
                                top = fldNode;
                            }
                        }
                    }

                    // restore top
                    top = tvSteps.Nodes[0];
                }
                else
                {
                    stepImageList.Images.Add(option.Image);
                    var index = stepImageList.Images.Count - 1;
                    top.Nodes.Add(
                        new TreeNode(option.Name)
                            {
                                ImageIndex = index,
                                SelectedImageIndex = index,
                                Tag = option,
                                ToolTipText = option.Description,
                            });
                }
            }

            top.ExpandAll();
            top.EnsureVisible();
            textBox1.Text = "a";
            textBox1.Text = "o";
            textBox1.Text = "e";

            textBox1.Text = "";

        }

        private void tvSteps_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(((TreeNode)e.Item).Tag, DragDropEffects.All);
        }
    }
}
