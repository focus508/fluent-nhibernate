﻿using System;
using System.Collections.Generic;

namespace FluentNHibernate.MappingModel.Collections
{
    public class ManyToManyMapping : MappingBase, ICollectionRelationshipMapping, IHasColumnMappings
    {
        private readonly AttributeStore<ManyToManyMapping> attributes = new AttributeStore<ManyToManyMapping>();
        private readonly IDefaultableList<ColumnMapping> columns = new DefaultableList<ColumnMapping>();
        
        public Type ParentType { get; set; }
        public Type ChildType { get; set; }

        public AttributeStore<ManyToManyMapping> Attributes
        {
            get { return attributes; }
        }

        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            visitor.ProcessManyToMany(this);

            foreach (var column in columns)
                visitor.Visit(column);
        }

        public TypeReference Class
        {
            get { return attributes.Get(x => x.Class); }
            set { attributes.Set(x => x.Class, value); }
        }

        public string ForeignKey
        {
            get { return attributes.Get(x => x.ForeignKey); }
            set { attributes.Set(x => x.ForeignKey, value); }
        }

        public string OuterJoin
        {
            get { return attributes.Get(x => x.OuterJoin); }
            set { attributes.Set(x => x.OuterJoin, value); }
        }

        public string Fetch
        {
            get { return attributes.Get(x => x.Fetch); }
            set { attributes.Set(x => x.Fetch, value); }
        }

        public string NotFound
        {
            get { return attributes.Get(x => x.NotFound); }
            set { attributes.Set(x => x.NotFound, value); }
        }

        public string Where
        {
            get { return attributes.Get(x => x.Where); }
            set { attributes.Set(x => x.Where, value); }
        }

        public Laziness Lazy
        {
            get { return attributes.Get(x => x.Lazy); }
            set { attributes.Set(x => x.Lazy, value); }
        }

        public IDefaultableEnumerable<ColumnMapping> Columns
        {
            get { return columns; }
        }

        public void AddColumn(ColumnMapping column)
        {
            columns.Add(column);
        }

        public void AddDefaultColumn(ColumnMapping column)
        {
            columns.AddDefault(column);
        }

        public void ClearColumns()
        {
            columns.Clear();
        }
    }
}
