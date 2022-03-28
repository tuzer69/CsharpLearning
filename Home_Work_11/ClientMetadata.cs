using System;
using System.Globalization;
using System.Windows;

namespace Task_1
{
    public class ClientMetadata : DependencyObject
    {
        #region Поля(Fields)

        public static readonly DependencyProperty DataTimeEditProperty;

        public static readonly DependencyProperty DataChangeProperty;

        public static readonly DependencyProperty TypeEditDependencyProperty;

        public static readonly DependencyProperty AutorEditProperty;

        #endregion

        #region Конструкторы(Constructors)

        public ClientMetadata(){}

        static ClientMetadata()
        {
            DataTimeEditProperty = DependencyProperty.Register(
                "DataTimeEdit",
                typeof(string),
                typeof(ClientMetadata),
                mDataTimeEdit,
                new ValidateValueCallback(ValidateValue)
            );

            DataChangeProperty = DependencyProperty.Register(
                "DataChange",
                typeof(string),
                typeof(ClientMetadata),
                metadataDataProp,
                new ValidateValueCallback(ValidateValue));

            TypeEditDependencyProperty = DependencyProperty.Register(
                "TypeEdit",
                typeof(string),
                typeof(ClientMetadata),
                metadataTypeEdit,
                new ValidateValueCallback(ValidateValue));

            AutorEditProperty = DependencyProperty.Register(
                "AutorEdit",
                typeof(string),
                typeof(ClientMetadata),
                metadataAutorEdit,
                new ValidateValueCallback(ValidateValue));

        }

        #endregion

        #region Методы(Methods)

        #region DependencyMethods

        private static bool ValidateValue(object value)
        {
            return true;
        }

        private static readonly FrameworkPropertyMetadata mDataTimeEdit = new FrameworkPropertyMetadata
        {
            CoerceValueCallback = new CoerceValueCallback(CorrectDateTime),
            AffectsMeasure = true,
            AffectsRender = true
        };
        private static object CorrectDateTime(DependencyObject d, object baseValue)
        {
            return (string)baseValue;
        }

        private static readonly FrameworkPropertyMetadata metadataDataProp = new FrameworkPropertyMetadata
        {
            CoerceValueCallback = new CoerceValueCallback(CorrectDateProp),
            AffectsMeasure = true,
            AffectsRender = true
        };
        private static object CorrectDateProp(DependencyObject d, object baseValue)
        {
            return (string)baseValue;
        }

        private static readonly FrameworkPropertyMetadata metadataTypeEdit = new FrameworkPropertyMetadata
        {
            CoerceValueCallback = new CoerceValueCallback(CorrectTypeEdit),
            AffectsMeasure = true,
            AffectsRender = true
        };

        private static object CorrectTypeEdit(DependencyObject d, object baseValue)
        {
            return (string)baseValue;
        }

        private static readonly FrameworkPropertyMetadata metadataAutorEdit = new FrameworkPropertyMetadata
        {
            CoerceValueCallback = new CoerceValueCallback(CorrectAutorEdit),
            AffectsMeasure = true,
            AffectsRender = true
        };

        private static object CorrectAutorEdit(DependencyObject d, object baseValue)
        {
            return (string)baseValue;
        }


        #endregion

        #endregion

        #region Свойства(Properties)
        public string DataTimeEdit
        {
            get => (string) GetValue(DataTimeEditProperty);
            set => SetValue(DataTimeEditProperty, value);
        }
        public string DataChange
        {
            get => (string)GetValue(DataChangeProperty);
            set => SetValue(DataChangeProperty, value);
        }
        public string TypeEdit
        {
            get => (string)GetValue(TypeEditDependencyProperty);
            set => SetValue(TypeEditDependencyProperty, value);
        }
        public string AutorEdit
        {
            get => (string) GetValue(AutorEditProperty);
            set => SetValue(AutorEditProperty, value);
        }

        #endregion

    }



}