using MediaMvvmcrossForms.ViewModels;
using System;
using System.Collections.Generic;

namespace MediaMvvmcrossForms.Common
{
    public static class Constants
    {
        public const string NavigationMode = "NavigationMode";
        public const string NavigationClearStack = "ClearStack";

        public static IDictionary<Type, string> Titles { get; } = new Dictionary<Type, string>
        {
            { typeof(FirstViewModel), "First Page" },
            { typeof(SecondViewModel), "Second Page" }
        };
    }
}