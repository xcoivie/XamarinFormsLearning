using System;
using System.Collections.Generic;
using System.Text;

namespace XFApp1.Calculator
{
    public interface IMarkupExtension
    {
        object ProvideValue(IServiceProvider serviceProvider);
    }
}
