﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Services
{
    public interface ILoader<T>
    {
        Task<T> Load();
    }
}
