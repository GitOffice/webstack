using System;
using System.Collections.Generic;
using System.Data;
using TableDescriptor;
using copper;
using tophat;

namespace bulky
{
    /// <summary>
    /// A consumer that bulk inserts objects in batches.
    /// By default, a tophat connection scope is used, or you may provide one through <see pref="ConnectionBuilder" />.
    /// By default, the object mapping is performed by TableDescriptor's <see cref="SimpleDescriptor" />, or you may provide a custom <see cref="Descriptor" />.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BulkCopyConsumer<T> : BatchingConsumer<T>
    {
        public Func<IDbConnection> ConnectionBuilder { get; set; }
        public Descriptor Descriptor { get; set; }
        public int Consumed { get; private set; }

        public BulkCopyConsumer(int itemsPerBatch) : base(itemsPerBatch)
        {
            InitializeDefaults();
        }

        public BulkCopyConsumer(TimeSpan interval) : base(interval)
        {
            InitializeDefaults();
        }

        public BulkCopyConsumer(int itemsPerBatch, TimeSpan orInterval) : base(itemsPerBatch, orInterval)
        {
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            Descriptor = SimpleDescriptor.Create<T>();
            ConnectionBuilder = () => UnitOfWork.Current;
        }

        public override bool Handle(IList<T> batch)
        {
            ConnectionBuilder().BulkCopy(Descriptor, batch);
            Consumed += batch.Count;
            return true;
        }
    }
}
