using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using HomeWork.ViewModel;
using HomeWork.Entities;

namespace HomeWork.Wrappers
{
    public class WrapperBase<TModel> : Bindable
    {
        private TModel _model;

        public TModel model
        {
            get => _model;
            set => _model = value;
        }

        public WrapperBase(TModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }



        protected void Set<TValue>(TValue value, [CallerMemberName] string properyName = null)
        {
            var propInfo = _model.GetType().GetProperty(properyName);
            var propValue = propInfo?.GetValue(_model, null);
            if (!Equals(propValue, value))
            {
                propInfo?.SetValue(_model, value, null);
                OnPropertyChanged(properyName);
            }
        }

        protected TValue Get<TValue>([CallerMemberName] string properyName = null)
        {
            var propInfo = _model.GetType().GetProperty(properyName);
            return (TValue)propInfo?.GetValue(_model, null);

        }

    }
 
}