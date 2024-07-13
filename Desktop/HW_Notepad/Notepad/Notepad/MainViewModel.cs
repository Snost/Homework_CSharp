using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;

namespace Notepad
{
    public class MainViewModel
    {
        public ICommand NewCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }
        public ICommand CutCommand { get; }

        public MainViewModel()
        {
            NewCommand = new GenericCommand(ExecuteNewCommand);
            OpenCommand = new GenericCommand(ExecuteOpenCommand);
            SaveCommand = new GenericCommand(ExecuteSaveCommand);
            CopyCommand = new GenericCommand(ExecuteCopyCommand, CanExecuteCopyCutCommand);
            PasteCommand = new GenericCommand(ExecutePasteCommand, CanExecutePasteCommand);
            CutCommand = new GenericCommand(ExecuteCutCommand, CanExecuteCopyCutCommand);
        }

        private void ExecuteNewCommand(object parameter)
        {
            ((MainWindow)Application.Current.MainWindow).textBox.Clear();
        }

        private void ExecuteOpenCommand(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ((MainWindow)Application.Current.MainWindow).textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void ExecuteSaveCommand(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, ((MainWindow)Application.Current.MainWindow).textBox.Text);
            }
        }

        private void ExecuteCopyCommand(object parameter)
        {
            if (CanExecuteCopyCutCommand(parameter))
            {
                ((MainWindow)Application.Current.MainWindow).textBox.Copy();
            }
        }
        private void ExecutePasteCommand(object parameter)
        {
            ((MainWindow)Application.Current.MainWindow).textBox.Paste();
        }

        private void ExecuteCutCommand(object parameter)
        {
            if (CanExecuteCopyCutCommand(parameter))
            {
                ((MainWindow)Application.Current.MainWindow).textBox.Cut();
            }
        }

        private bool CanExecuteCopyCutCommand(object parameter)
        {
            return !string.IsNullOrEmpty(((MainWindow)Application.Current.MainWindow).textBox.SelectedText);
        }
        private bool CanExecutePasteCommand(object parameter)
        {
            return Clipboard.ContainsText();
        }
    }


}