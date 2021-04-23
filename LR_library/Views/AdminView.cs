using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_library.Controllers;
using LR_library.Forms;

namespace LR_library.Views
{
    public partial class AdminView : Form
    {
        public MainView mainForm;

        public AdminView()
        {
            InitializeComponent();
        }

        public AdminView(MainView mainForm)
        {
            this.mainForm = mainForm;
        }

        private void AdminView_Load(object sender, EventArgs e)
        {
            DrawUsers();
        }

        private void AdminView_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Close();
        }

        private void DrawUsers()
        {
            groupBoxUsers.Controls.Clear();
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    var controller = new UserController(user);
                    Panel panel = new Panel()
                    {
                        Dock = DockStyle.Top,
                        Height = 50,
                        BorderStyle = BorderStyle.FixedSingle,

                    };
                    Label login = new Label()
                    {
                        Dock = DockStyle.Left,
                        Width = 150,
                        Text = user.Login,
                        Font = new Font("Verdana", 10.0f),
                    };

                    Label role = new Label()
                    {
                        Dock = DockStyle.Left,
                        Text = user.Role,
                        Font = new Font("Verdana", 10.0f),
                        Width = 150,

                    };
                    Label id = new Label()
                    {
                        Dock = DockStyle.Left,
                        Text = user.Id.ToString(),
                        Font = new Font("Verdana", 10.0f),
                        Width = 50,

                    };

                    Button changeButton = new Button()
                    {
                        Text = "изменить",
                        ForeColor = Color.White,
                        Font = new Font("Verdana", 10.0f),
                        BackColor = Color.LightGreen,
                        Dock = DockStyle.Right,
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(100, 10),
                    };

                    Button deleteButton = new Button()
                    {
                        Text = "удалить",
                        ForeColor = Color.White,
                        Font = new Font("Verdana", 10.0f),
                        BackColor = Color.DarkRed,
                        Dock = DockStyle.Right,
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(100, 10),
                    };
                    deleteButton.Click += controller.Delete;
                    deleteButton.Click += this.DrawUsers;

                    void change(object s, EventArgs e)
                    {                        
                        ModifyUserForm form = new ModifyUserForm(controller);
                        StandaloneView standaloneView = new StandaloneView(this, form);
                        standaloneView.Show();
                    }

                    changeButton.Click += change;
                    changeButton.Click += DrawUsers;

                    panel.Controls.Add(changeButton);
                    panel.Controls.Add(deleteButton);
                    panel.Controls.Add(id);
                    panel.Controls.Add(role);
                    panel.Controls.Add(login);

                    groupBoxUsers.Controls.Add(panel);
                }
            }
        }

        private void DrawUsers(object sender, EventArgs e)
        {
            DrawUsers();
        }

        private void linkLabelCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserCreationForm form = new UserCreationForm();
            StandaloneView standaloneView = new StandaloneView(this, form);
            standaloneView.Show();
        }
    }
}
