using System;
using Xamarin.Forms;

namespace Framework.Xamariner
{
    // License Url: https://github.com/xamarin/xamarin-forms-samples/
    /*
    License

    The Apache License 2.0 applies to all samples in this repository.

    Copyright 2011 Xamarin Inc

    Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0
    Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
     */

    /// <summary>
    /// https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/behaviors/reusable/event-to-command-behavior/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Xamarin.Forms.Behavior{T}" />
    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo (T bindable)
        {
            base.OnAttachedTo (bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null) {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom (T bindable)
        {
            base.OnDetachingFrom (bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        void OnBindingContextChanged (object sender, EventArgs e)
        {
            OnBindingContextChanged ();
        }

        protected override void OnBindingContextChanged ()
        {
            base.OnBindingContextChanged ();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}

