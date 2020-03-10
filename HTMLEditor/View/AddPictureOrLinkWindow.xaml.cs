﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HTMLEditor.Core;

namespace HTMLEditor.View
{
    /// <summary>
    /// Interaction logic for AddPictureOrLinkWindow.xaml
    /// </summary>
    public partial class AddPictureOrLinkWindow : Window
    {
        bool isImage;

        public string ResultAlt { get; set; }
        public string ResultPath { get; set; }

        public AddPictureOrLinkWindow(bool isImg = true)
        {
            isImage = isImg;

            InitializeComponent();
        }

        private void openFileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            string imgPath = DialogBox.SelectImage();
            if (string.IsNullOrEmpty(imgPath))
            {
                return;
            }

            pathTextBox.Text = imgPath;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (isImage)
            {
                Title = "Выставить картинку";
                label.Content = "Введите путь к файлу:";
            }
            else
            {
                Title = "Вставить ссылку";
                label.Content = "Ввдите ссылку:";
                openFileDialogButton.Visibility = Visibility.Collapsed;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ResultPath = pathTextBox.Text;
            ResultAlt = altTextBox.Text ?? "";

            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            ResultPath = pathTextBox.Text;
            ResultAlt = altTextBox.Text ?? "";

            DialogResult = false;
        }
    }
}