﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Entities.Base
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}