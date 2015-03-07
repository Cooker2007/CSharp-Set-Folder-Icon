namespace FolderIconSetter.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// The view model base.
    /// </summary>
    internal class ViewModelBase : INotifyPropertyChanged
    {
        #region Fields

        //// Extra Stuff, shows why a base ViewModel is useful

        /// <summary>
        /// The close window flag.
        /// </summary>
        private bool? closeWindowFlag;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        protected ViewModelBase()
        {
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the close window flag is set.
        /// </summary>
        public bool? CloseWindowFlag
        {
            get
            {
                return this.closeWindowFlag;
            }

            set
            {
                this.closeWindowFlag = value;
                this.RaisePropertyChanged("CloseWindowFlag");
            }
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The close window.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() => { CloseWindowFlag = CloseWindowFlag == null ? true : !CloseWindowFlag; }));
        }

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This
        /// method does not exist in a Release build.
        /// </summary>
        /// <param name="propertyName">
        /// The property Name.
        /// </param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }
                else
                {
                    Debug.Fail(msg);
                }
            }
        }

        /// <summary>
        /// Raise property changed event.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        internal void RaisePropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Methods
    }
}