﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCupNote
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DCupNoteDB")]
	public partial class DCupNoteDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDCupNote(DCupNote instance);
    partial void UpdateDCupNote(DCupNote instance);
    partial void DeleteDCupNote(DCupNote instance);
    partial void InsertTagNote(TagNote instance);
    partial void UpdateTagNote(TagNote instance);
    partial void DeleteTagNote(TagNote instance);
    #endregion
		
		public DCupNoteDataClassesDataContext() : 
				base(global::DCupNote.Properties.Settings.Default.DCupNoteDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DCupNoteDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DCupNoteDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DCupNoteDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DCupNoteDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DCupNote> DCupNotes
		{
			get
			{
				return this.GetTable<DCupNote>();
			}
		}
		
		public System.Data.Linq.Table<TagNote> TagNotes
		{
			get
			{
				return this.GetTable<TagNote>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DCupNote")]
	public partial class DCupNote : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ID_DCupNote;
		
		private string _Title;
		
		private string _Notes_DCN;
		
		private System.Data.Linq.Binary _Image;
		
		private EntitySet<TagNote> _TagNotes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_DCupNoteChanging(string value);
    partial void OnID_DCupNoteChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnNotes_DCNChanging(string value);
    partial void OnNotes_DCNChanged();
    partial void OnImageChanging(System.Data.Linq.Binary value);
    partial void OnImageChanged();
    #endregion
		
		public DCupNote()
		{
			this._TagNotes = new EntitySet<TagNote>(new Action<TagNote>(this.attach_TagNotes), new Action<TagNote>(this.detach_TagNotes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_DCupNote", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ID_DCupNote
		{
			get
			{
				return this._ID_DCupNote;
			}
			set
			{
				if ((this._ID_DCupNote != value))
				{
					this.OnID_DCupNoteChanging(value);
					this.SendPropertyChanging();
					this._ID_DCupNote = value;
					this.SendPropertyChanged("ID_DCupNote");
					this.OnID_DCupNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(200)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Notes_DCN", DbType="NVarChar(MAX)")]
		public string Notes_DCN
		{
			get
			{
				return this._Notes_DCN;
			}
			set
			{
				if ((this._Notes_DCN != value))
				{
					this.OnNotes_DCNChanging(value);
					this.SendPropertyChanging();
					this._Notes_DCN = value;
					this.SendPropertyChanged("Notes_DCN");
					this.OnNotes_DCNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DCupNote_TagNote", Storage="_TagNotes", ThisKey="ID_DCupNote", OtherKey="ID_DCupNote")]
		public EntitySet<TagNote> TagNotes
		{
			get
			{
				return this._TagNotes;
			}
			set
			{
				this._TagNotes.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TagNotes(TagNote entity)
		{
			this.SendPropertyChanging();
			entity.DCupNote = this;
		}
		
		private void detach_TagNotes(TagNote entity)
		{
			this.SendPropertyChanging();
			entity.DCupNote = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TagNote")]
	public partial class TagNote : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ID_TagNote;
		
		private string _ID_DCupNote;
		
		private int _LocationX;
		
		private int _LocationY;
		
		private string _Notes_TN;
		
		private EntityRef<DCupNote> _DCupNote;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_TagNoteChanging(string value);
    partial void OnID_TagNoteChanged();
    partial void OnID_DCupNoteChanging(string value);
    partial void OnID_DCupNoteChanged();
    partial void OnLocationXChanging(int value);
    partial void OnLocationXChanged();
    partial void OnLocationYChanging(int value);
    partial void OnLocationYChanged();
    partial void OnNotes_TNChanging(string value);
    partial void OnNotes_TNChanged();
    #endregion
		
		public TagNote()
		{
			this._DCupNote = default(EntityRef<DCupNote>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_TagNote", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ID_TagNote
		{
			get
			{
				return this._ID_TagNote;
			}
			set
			{
				if ((this._ID_TagNote != value))
				{
					this.OnID_TagNoteChanging(value);
					this.SendPropertyChanging();
					this._ID_TagNote = value;
					this.SendPropertyChanged("ID_TagNote");
					this.OnID_TagNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_DCupNote", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ID_DCupNote
		{
			get
			{
				return this._ID_DCupNote;
			}
			set
			{
				if ((this._ID_DCupNote != value))
				{
					if (this._DCupNote.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_DCupNoteChanging(value);
					this.SendPropertyChanging();
					this._ID_DCupNote = value;
					this.SendPropertyChanged("ID_DCupNote");
					this.OnID_DCupNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocationX", DbType="Int NOT NULL")]
		public int LocationX
		{
			get
			{
				return this._LocationX;
			}
			set
			{
				if ((this._LocationX != value))
				{
					this.OnLocationXChanging(value);
					this.SendPropertyChanging();
					this._LocationX = value;
					this.SendPropertyChanged("LocationX");
					this.OnLocationXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocationY", DbType="Int NOT NULL")]
		public int LocationY
		{
			get
			{
				return this._LocationY;
			}
			set
			{
				if ((this._LocationY != value))
				{
					this.OnLocationYChanging(value);
					this.SendPropertyChanging();
					this._LocationY = value;
					this.SendPropertyChanged("LocationY");
					this.OnLocationYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Notes_TN", DbType="NVarChar(MAX)")]
		public string Notes_TN
		{
			get
			{
				return this._Notes_TN;
			}
			set
			{
				if ((this._Notes_TN != value))
				{
					this.OnNotes_TNChanging(value);
					this.SendPropertyChanging();
					this._Notes_TN = value;
					this.SendPropertyChanged("Notes_TN");
					this.OnNotes_TNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DCupNote_TagNote", Storage="_DCupNote", ThisKey="ID_DCupNote", OtherKey="ID_DCupNote", IsForeignKey=true)]
		public DCupNote DCupNote
		{
			get
			{
				return this._DCupNote.Entity;
			}
			set
			{
				DCupNote previousValue = this._DCupNote.Entity;
				if (((previousValue != value) 
							|| (this._DCupNote.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DCupNote.Entity = null;
						previousValue.TagNotes.Remove(this);
					}
					this._DCupNote.Entity = value;
					if ((value != null))
					{
						value.TagNotes.Add(this);
						this._ID_DCupNote = value.ID_DCupNote;
					}
					else
					{
						this._ID_DCupNote = default(string);
					}
					this.SendPropertyChanged("DCupNote");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
