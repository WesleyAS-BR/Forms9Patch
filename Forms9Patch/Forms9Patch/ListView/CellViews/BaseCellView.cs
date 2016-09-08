﻿using Xamarin.Forms;

namespace Forms9Patch
{
	/// <summary>
	/// DO NOT USE: Used by Forms9Patch.ListView as a foundation for cells.
	/// </summary>
	class BaseCellView : Xamarin.Forms.ContentView
	{
		/// <summary>
		/// The separator is visible property.
		/// </summary>
		internal static readonly BindableProperty SeparatorIsVisibleProperty = BindableProperty.Create("SeparatorIsVisible",typeof(bool), typeof(BaseCellView), true);
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:Forms9Patch.BaseCellView"/> separator is visible.
		/// </summary>
		/// <value><c>true</c> if separator is visible; otherwise, <c>false</c>.</value>
		internal bool SeparatorIsVisible {
			get { return (bool)GetValue (SeparatorIsVisibleProperty); }
			set { 
				SetValue (SeparatorIsVisibleProperty, value); 
			}
		}

		/// <summary>
		/// The separator color property.
		/// </summary>
		internal static readonly BindableProperty SeparatorColorProperty = BindableProperty.Create ("SeparatorColor", typeof(Color), typeof(BaseCellView), default(Color));
		/// <summary>
		/// Gets or sets the color of the separator.
		/// </summary>
		/// <value>The color of the separator.</value>
		internal Color SeparatorColor {
			get { return (Color)GetValue (SeparatorColorProperty); }
			set { SetValue (SeparatorColorProperty, value); }
		}

		/// <summary>
		/// The separator height property.
		/// </summary>
		public static readonly BindableProperty SeparatorHeightProperty = BindableProperty.Create ("SeparatorHeight", typeof(double), typeof(BaseCellView), -1.0);
		/// <summary>
		/// Gets or sets the height of the separator.
		/// </summary>
		/// <value>The height of the separator.</value>
		public double SeparatorHeight {
			get { return (double)GetValue (SeparatorHeightProperty); }
			set { SetValue (SeparatorHeightProperty, value); }
		}

		/// <summary>
		/// The separator left indent property.
		/// </summary>
		public static readonly BindableProperty SeparatorLeftIndentProperty = BindableProperty.Create ("SeparatorLeftIndent", typeof(double), typeof(BaseCellView), 20.0);
		/// <summary>
		/// Gets or sets the separator left indent.
		/// </summary>
		/// <value>The separator left indent.</value>
		public double SeparatorLeftIndent {
			get { return (double)GetValue (SeparatorLeftIndentProperty); }
			set { SetValue (SeparatorLeftIndentProperty, value); }
		}

		/// <summary>
		/// The separator right indent property.
		/// </summary>
		public static readonly BindableProperty SeparatorRightIndentProperty = BindableProperty.Create ("SeparatorRightIndent", typeof(double), typeof(BaseCellView), 0.0);
		/// <summary>
		/// Gets or sets the separator right indent.
		/// </summary>
		/// <value>The separator right indent.</value>
		public double SeparatorRightIndent {
			get { return (double)GetValue (SeparatorRightIndentProperty); }
			set { SetValue (SeparatorRightIndentProperty, value); }
		}

		/// <summary>
		/// DO NOT USE: Initializes a new instance of the <see cref="T:Forms9Patch.BaseCellView"/> class.
		/// </summary>
		public BaseCellView () {
	 		//Padding = new Thickness(5,5,5,5);
			//_listener = new FormsGestures.Listener(this);
			//_listener.LongPressing += OnLongPressing;
			//_listener.LongPressed += OnLongPressed;
			//BackgroundColor = Color.Transparent;

			this.SetBinding (SeparatorIsVisibleProperty, "SeparatorIsVisible");
			//this.SetBinding (BackgroundColorProperty, "BackgroundColor");
		}

		/// <summary>
		/// Triggered by a change in the binding context
		/// </summary>
		protected override void OnBindingContextChanged () {
			var item = BindingContext as Item;
			if (item != null) {
				item.BaseCellView = this;
			}
			var type = BindingContext?.GetType ();
			if (type == typeof(NullItem) || type == typeof(BlankItem))
				Content.BindingContext = item;
			else
				Content.BindingContext = item?.Source;
			base.OnBindingContextChanged ();
		}

		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == Item.IsSelectedProperty.PropertyName)
			{
				var item = BindingContext as Item;
				if (item != null)
					BackgroundColor = item.IsSelected ? item.SelectedBackgroundColor : item.BackgroundColor;
			}
		}

	}
}

