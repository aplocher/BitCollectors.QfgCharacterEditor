﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using BitCollectors.QfgCharacterEditor.Library;
using BitCollectors.QfgCharacterEditor.Library.Enums;
using BitCollectors.QfgCharacterEditor.WinUI.Properties;

namespace BitCollectors.QfgCharacterEditor.WinUI
{
    public partial class MainForm : Form
    {
        private readonly QfgCharacter _character = null;

        public MainForm()
        {
            InitializeComponent();

            _character = new QfgCharacter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboQfgGames.DataSource = Enum.GetValues(typeof(QfgGames));

            RefreshCharacterClass();

            qfgCharacterBindingSource.DataSource = _character;

            ProcessCommandLineArgs();
        }

        private void characterStats_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox = (TextBox)sender;
                int textValue;

                if (int.TryParse(textBox.Text, out textValue))
                {
                    if (textValue > _character.QfgGameInfo.MaxCharacterStatValue || textValue < 0)
                    {
                        errorProvider1.SetError(textBox, "The value cannot be greater than " + _character.QfgGameInfo.MaxCharacterStatValue.ToString());
                    }
                    else
                    {
                        errorProvider1.SetError(textBox, null);
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox, "Must be a numeric value no greater than " + _character.QfgGameInfo.MaxCharacterStatValue.ToString());
                }
            }
        }

        private void magicStats_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox = (TextBox)sender;
                int textValue;

                if (int.TryParse(textBox.Text, out textValue))
                {
                    if (textValue > _character.QfgGameInfo.MaxMagicStatValue || textValue < 0)
                    {
                        errorProvider1.SetError(textBox, "The value cannot be greater than " + _character.QfgGameInfo.MaxCharacterStatValue.ToString());
                    }
                    else
                    {
                        errorProvider1.SetError(textBox, null);
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox, "Must be a numeric value no greater than " + _character.QfgGameInfo.MaxCharacterStatValue.ToString());
                }
            }
        }

        private void tbtnLoad_Click(object sender, EventArgs e)
        {
            if (_character.IsDirty)
            {
                if (DialogResult.Cancel == MessageBox.Show("You have unsaved changes.  Are you sure you want to open a different character file?", "Unsaved changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    return;
                }
            }

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "QFG Export Files (*.sav)|*.sav|All Files (*.*)|*.*";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadFile(openDialog.FileName);
                }
            }
        }

        private void ShowSaveDialog()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "QFG Export Files (*.sav)|*.sav|All Files (*.*)|*.*";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFile(saveDialog.FileName);
                }
            }
        }

        private void tbtnSave_Click(object sender, EventArgs e)
        {
            ShowSaveDialog();
        }

        private void tbtnMaxValues_Click(object sender, EventArgs e)
        {

            _character.SetMaxValues();

            qfgCharacterBindingSource.ResetBindings(false);

            this.ValidateChildren();
        }

        private void ProcessCommandLineArgs()
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                LoadFile(args[1]);
            }

        }

        private void LoadFile(string filename)
        {
            try
            {
                _character.LoadCharacter(filename);
                qfgCharacterBindingSource.DataSource = _character;

                cboQfgGames.SelectedItem = _character.QfgGame;
                cboCharacterClasses.SelectedItem = _character.QfgClass;

                qfgCharacterBindingSource.ResetBindings(false);

                SetFilename(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Importing Character", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFile(string filename)
        {
            _character.QfgGame = (QfgGames)cboQfgGames.SelectedItem;
            _character.QfgClass = (QfgClasses)cboCharacterClasses.SelectedItem;

            _character.EncodeToFile(filename);

            SetFilename(filename);

            MessageBox.Show("Character exported to file from " + _character.QfgGame.ToString(), "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetFilename(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            tlblCurrentFile.Text = string.Format("Current file: {0}", fileInfo.Name);
            this.Text = string.Format("QFG Character Editor - {0}", fileInfo.Name);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_character.IsDirty)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save your character before quiting?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Cancel)
                    e.Cancel = true;
                else if (dialogResult == DialogResult.Yes)
                    ShowSaveDialog();
            }
        }

        private void cboQfgGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            _character.QfgGame = (QfgGames)cboQfgGames.SelectedItem;

            RefreshCharacterClass();
            RefreshCharacterImage();

            qfgCharacterBindingSource.DataSource = _character;
            qfgCharacterBindingSource.ResetBindings(false);
        }

        private void cboCharacterClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCharacterImage();
        }

        private void RefreshCharacterClass()
        {
            Array classes = Enum.GetValues(typeof(QfgClasses));

            if (_character.QfgGameInfo.HasPaladin)
            {
                cboCharacterClasses.DataSource = classes;
            }
            else
            {
                List<QfgClasses> newList = new List<QfgClasses>();
                foreach (QfgClasses item in classes)
                {
                    if (Enum.GetName(typeof(QfgClasses), item) != "Paladin")
                    {
                        newList.Add(item);
                    }
                }

                cboCharacterClasses.DataSource = newList;
            }
        }

        private void RefreshCharacterImage()
        {
            if (cboCharacterClasses.SelectedItem == null || cboQfgGames.SelectedItem == null)
            {
                pbCharacterImage.Image = null;
            }
            else
            {
                switch ((QfgGames)cboQfgGames.SelectedItem)
                {
                    case QfgGames.QFG1:

                        switch ((QfgClasses)cboCharacterClasses.SelectedItem)
                        {
                            case QfgClasses.Fighter:
                                pbCharacterImage.Image = Resources.QFG1_Fighter;
                                break;

                            case QfgClasses.Magic:
                                pbCharacterImage.Image = Resources.QFG1_Mage;
                                break;

                            case QfgClasses.Thief:
                                pbCharacterImage.Image = Resources.QFG1_Thief;
                                break;

                            default:
                                pbCharacterImage.Image = null;
                                break;
                        }

                        break;

                    case QfgGames.QFG2:
                        switch ((QfgClasses)cboCharacterClasses.SelectedItem)
                        {
                            case QfgClasses.Fighter:
                            case QfgClasses.Paladin:
                                pbCharacterImage.Image = Resources.QFG2_Fighter;
                                break;

                            case QfgClasses.Magic:
                                pbCharacterImage.Image = Resources.QFG2_Mage;
                                break;

                            case QfgClasses.Thief:
                                pbCharacterImage.Image = Resources.QFG2_Thief;
                                break;

                            default:
                                pbCharacterImage.Image = null;
                                break;
                        }
                        break;

                    default:
                        pbCharacterImage.Image = null;
                        break;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ValidateChildren();
        }

        private void tbtnAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }
    }
}
