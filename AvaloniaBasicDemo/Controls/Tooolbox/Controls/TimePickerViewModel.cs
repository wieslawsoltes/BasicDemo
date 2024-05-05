using System;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class TimePickerViewModel : ToolboxControlViewModel
{
    public TimePickerViewModel()
    {
        Name = "TimePicker";
        Group = "Date and Time";
    }

    public override Control CreatePreview()
    {
        var timePicker = new TimePicker();
        timePicker.SelectedTime = DateTime.Now.TimeOfDay;
        timePicker.Background = Brushes.Black;
        return timePicker;
    }

    public override Control CreateControl()
    {
        var timePicker = new TimePicker();
        timePicker.SelectedTime = DateTime.Now.TimeOfDay;
        //timePicker.Background = Brushes.Blue;
        return timePicker;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not TimePicker timePicker)
        {
            return;
        }

        timePicker.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
