﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LoadCell.Core
{
    public interface ISensor
    {
        float Value { get; }
        void SetZero();
        void SetScale(float ScaleValue);
    }
}