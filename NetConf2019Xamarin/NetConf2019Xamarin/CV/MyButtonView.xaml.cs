using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetConf2019Xamarin.CV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyButtonView : ContentView
    {
        public MyButtonView()
        {
            InitializeComponent();
        }

        public Color ColorFondo
        {
            get => (Color)GetValue(ColorFondoProperty);
            set => SetValue(ColorFondoProperty, value);
        }
        public static readonly BindableProperty ColorFondoProperty = BindableProperty.Create(nameof(ColorFondo), typeof(Color), typeof(MyButtonView), Color.Green,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var me = (MyButtonView)bindable;
            me.ColorFondo = (Color)newValue;
            me.background.BackgroundColor = me.ColorFondo;
        });

        public string Texto
        {
            get => (string)GetValue(TextoProperty);
            set => SetValue(TextoProperty, value);
        }
        public static readonly BindableProperty TextoProperty = BindableProperty.Create(nameof(Texto), typeof(string), typeof(MyButtonView), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var me = (MyButtonView)bindable;
            me.Texto = (string)newValue;
            me.text.Text = me.Texto;
        });

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MyButtonView), default(ICommand),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var me = (MyButtonView)bindable;
            me.Command = (ICommand)newValue;
            me.command.Command = me.Command;
        });
    }
}