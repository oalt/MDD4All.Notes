using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MDD4All.MVVM
{
    public class DesignerLibrary
    {
        private static DesignerPlatformLibrary? _detectedDesignerPlatformLibrary;

        private static bool? _isInDesignMode;

        internal static DesignerPlatformLibrary DetectedDesignerLibrary
        {
            get
            {
                if (!_detectedDesignerPlatformLibrary.HasValue)
                {
                    _detectedDesignerPlatformLibrary = GetCurrentPlatform();
                }

                return _detectedDesignerPlatformLibrary.Value;
            }
        }

        public static bool IsInDesignModeStatic
        {
            get
            {
                bool result = false;

                if (!_isInDesignMode.HasValue)
                {
                    _isInDesignMode = IsInDesignModePortable();
                }

                result = _isInDesignMode.Value;

                return result;
            }
        }

        private static DesignerPlatformLibrary GetCurrentPlatform()
        {
            if ((object)Type.GetType("System.ComponentModel.DesignerProperties, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e") != null)
            {
                return DesignerPlatformLibrary.Silverlight;
            }

            if ((object)Type.GetType("System.ComponentModel.DesignerProperties, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35") != null)
            {
                return DesignerPlatformLibrary.Net;
            }

            if ((object)Type.GetType("Windows.ApplicationModel.DesignMode, Windows, ContentType=WindowsRuntime") != null)
            {
                return DesignerPlatformLibrary.WinRt;
            }

            return DesignerPlatformLibrary.Unknown;
        }

        private static bool IsInDesignModePortable()
        {
            switch (DetectedDesignerLibrary)
            {
                case DesignerPlatformLibrary.WinRt:
                    return IsInDesignModeMetro();
                case DesignerPlatformLibrary.Silverlight:
                    {
                        bool flag = IsInDesignModeSilverlight();
                        if (!flag)
                        {
                            flag = IsInDesignModeNet();
                        }

                        return flag;
                    }
                case DesignerPlatformLibrary.Net:
                    return IsInDesignModeNet();
                default:
                    return false;
            }
        }

        private static bool IsInDesignModeSilverlight()
        {
            try
            {
                Type type = Type.GetType("System.ComponentModel.DesignerProperties, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e");
                if ((object)type == null)
                {
                    return false;
                }

                PropertyInfo declaredProperty = type.GetTypeInfo().GetDeclaredProperty("IsInDesignTool");
                if ((object)declaredProperty == null)
                {
                    return false;
                }

                return (bool)declaredProperty.GetValue(null, null);
            }
            catch
            {
                return false;
            }
        }

        private static bool IsInDesignModeMetro()
        {
            try
            {
                return (bool)Type.GetType("Windows.ApplicationModel.DesignMode, Windows, ContentType=WindowsRuntime").GetTypeInfo().GetDeclaredProperty("DesignModeEnabled")
                    .GetValue(null, null);
            }
            catch
            {
                return false;
            }
        }

        private static bool IsInDesignModeNet()
        {
            try
            {
                Type type = Type.GetType("System.ComponentModel.DesignerProperties, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                if ((object)type == null)
                {
                    return false;
                }

                object value = type.GetTypeInfo().GetDeclaredField("IsInDesignModeProperty").GetValue(null);
                Type type2 = Type.GetType("System.ComponentModel.DependencyPropertyDescriptor, WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                Type type3 = Type.GetType("System.Windows.FrameworkElement, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                if ((object)type2 == null || (object)type3 == null)
                {
                    return false;
                }

                List<MethodInfo> list = type2.GetTypeInfo().GetDeclaredMethods("FromProperty").ToList();
                if (list == null || list.Count == 0)
                {
                    return false;
                }

                MethodInfo methodInfo = list.FirstOrDefault((MethodInfo mi) => mi.IsPublic && mi.IsStatic && mi.GetParameters().Length == 2);
                if ((object)methodInfo == null)
                {
                    return false;
                }

                object obj = methodInfo.Invoke(null, new object[2] { value, type3 });
                if (obj == null)
                {
                    return false;
                }

                PropertyInfo declaredProperty = type2.GetTypeInfo().GetDeclaredProperty("Metadata");
                if ((object)declaredProperty == null)
                {
                    return false;
                }

                object value2 = declaredProperty.GetValue(obj, null);
                Type type4 = Type.GetType("System.Windows.PropertyMetadata, WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                if (value2 == null || (object)type4 == null)
                {
                    return false;
                }

                PropertyInfo declaredProperty2 = type4.GetTypeInfo().GetDeclaredProperty("DefaultValue");
                if ((object)declaredProperty2 == null)
                {
                    return false;
                }

                return (bool)declaredProperty2.GetValue(value2, null);
            }
            catch
            {
                return false;
            }
        }
    }
}
