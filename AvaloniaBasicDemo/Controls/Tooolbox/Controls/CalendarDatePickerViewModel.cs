using System;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class CalendarDatePickerViewModel : ToolboxControlViewModel
{
    public CalendarDatePickerViewModel()
    {
        Name = "CalendarDatePicker";
        Group = "Date and Time";
    }

    public override Control CreatePreview()
    {
        var calendarDatePicker = new CalendarDatePicker();
        calendarDatePicker.SelectedDate = DateTime.Now;
        calendarDatePicker.Background = Brushes.Black;
        return calendarDatePicker;
    }

    public override Control CreateControl()
    {
        var calendarDatePicker = new CalendarDatePicker();
        calendarDatePicker.SelectedDate = DateTime.Now;
        //calendarDatePicker.Background = Brushes.Blue;
        return calendarDatePicker;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not CalendarDatePicker calendarDatePicker)
        {
            return;
        }

        calendarDatePicker.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
