﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PbPTweetAggregator.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pay_by_phone,PayByPhone,PayByPhone_UK")]
        public string TwitterUsers {
            get {
                return ((string)(this["TwitterUsers"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("40456506-Uu6ZZH9MNVNbzNp8tOPnclxcDzoNxhNIcIE6g4doH")]
        public string TwitterAccessToken {
            get {
                return ((string)(this["TwitterAccessToken"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4EZLV0AMpdlPX0Nsmol2Csua8UXJvTrd4yP4Vcyfe4")]
        public string TwitterAccessTokenSecret {
            get {
                return ((string)(this["TwitterAccessTokenSecret"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("XnyL4zGLfCnduxpyHkaImg")]
        public string TwitterConsumerKey {
            get {
                return ((string)(this["TwitterConsumerKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PqXTvQT6rd5Kzy0IEXAb6LnDtYXJagk5rHI1cZFgP4")]
        public string TwitterConsumerKeySecret {
            get {
                return ((string)(this["TwitterConsumerKeySecret"]));
            }
        }
    }
}