using System;
using Xamarin.Forms;

namespace datepicker
{
    public class MyDatePicker : DatePicker
    {
        const string PICKCONST = "Pick ...";
        string _format = null;
        //public static readonly BindableProperty NullableDateProperty = BindableProperty.Create<MyDatePicker, DateTime?>(p => p.NullableDate, null);

        public static readonly BindableProperty NullableDateProperty = BindableProperty.Create(nameof(NullableDate),
            typeof(DateTime),
            typeof(MyDatePicker), DateTime.Now, BindingMode.TwoWay);

        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); }
        }

        void UpdateDate(){
            if (NullableDate.HasValue)
            {
                Format = _format;
                Date = NullableDate.Value;
            }
            else
                Format = PICKCONST;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "NullableDate") UpdateDate();
            if (propertyName == "Date") NullableDate = Date;
            if (propertyName =="Format") 
                if(Format != PICKCONST)
                    _format = Format;
        }
    }
}
