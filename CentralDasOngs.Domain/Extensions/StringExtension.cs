using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDasOngs.Domain.Extensions
{
    public static class StringExtension
    {
       public static bool NotEmpty([NotNullWhen(true)]this string? value)
        {
            return string.IsNullOrWhiteSpace(value).IsFalse();
        }
    }
}
