using System;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class DatePickerViewModel : ToolboxControlViewModel
{
    public DatePickerViewModel()
    {
        Name = "DatePicker";
        Group = "Date and Time";
    }

    public override Control CreatePreview()
    {
        var datePicker = new DatePicker();
        datePicker.SelectedDate = DateTimeOffset.Now;
        datePicker.Background = Brushes.Black;
        return datePicker;
    }

    public override Control CreateControl()
    {
        var datePicker = new DatePicker();
        datePicker.SelectedDate = DateTimeOffset.Now;
        //textBox.Background = Brushes.Blue;
        return datePicker;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not DatePicker datePicker)
        {
            return;
        }

        datePicker.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
