﻿namespace AY.db.clientDataSetTableAdapters
{
}
namespace AY.db {
    public partial class clientDataSet {
	}
}

namespace AY.db.clientDataSetTableAdapters 
{
	public partial class TableAdapterManager
	{
		private vPaymentsTableAdapter _vPaymentsTableAdapter;

		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" +
			"ft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
			"", "System.Drawing.Design.UITypeEditor")]
		public vPaymentsTableAdapter vPaymentsTableAdapter
		{
			get
			{
				return this._vPaymentsTableAdapter;
			}
			set
			{
				this._vPaymentsTableAdapter = value;
			}
		}
    }
}
