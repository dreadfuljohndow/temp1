using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using MonkeyDo.WinApp.Services;

namespace MonkeyDo.WinApp.DataModel
{
    public sealed class ToDoItemModel : INotifyPropertyChanged
    {
        private readonly ToDoListService _toDoListService;

        public ToDoItemModel(ToDoListService service)
        {
            _toDoListService = service;
        }

        public string? Id { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectId { get; set; }
        public string? IdeaName { get; set; }

        public bool IsRed { get; set; }

        public string BackColorString
        {
            get
            {
                if (IsRed)
                {
                    return Color.Green.Name;
                }
                else
                {
                    return Color.Red.Name;
                }
            }
        }

        public Color BackColor
        {
            get
            {
                if (IsRed)
                {
                    return Color.Green;
                }
                else
                {
                    return Color.Red;
                }
            }
        }

        public void Checked()
        {
            //Console.WriteLine($"item checked. title is ::::::::: {Description}");

            if (!string.IsNullOrWhiteSpace(Id))
            {
                var item = _toDoListService.GetToDoItemById(Id);
                item.IsChecked = IsChecked;

                _toDoListService.UpdateToDoItem(this);
            }


            Description = "new description after update";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        public event PropertyChangedEventHandler? PropertyChanged = delegate{};

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}