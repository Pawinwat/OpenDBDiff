﻿using OpenDBDiff.Abstractions.Schema.Events;
using OpenDBDiff.Abstractions.Schema.Model;
using OpenDBDiff.Abstractions.Ui;
using OpenDBDiff.Schema.SQLServer.Generates.Generates;

namespace OpenDBDiff.SqlServer.Ui
{
    public class SQLServerGenerator : IGenerator
    {
        private readonly Generate Generate;

        public event ProgressEventHandler.ProgressHandler OnProgress;

        public SQLServerGenerator(string connectionString, IOption option)
        {
            this.Generate = new Generate()
            {
                ConnectionString = connectionString,
                Options = new Schema.SQLServer.Generates.Options.SqlOption(option)
            };
            this.Generate.OnProgress += new ProgressEventHandler.ProgressHandler(args =>
            {
                if (OnProgress != null)
                    OnProgress.Invoke(args);
            });

        }

        public int GetMaxValue()
        {
            return Generate.MaxValue;
        }

        public IDatabase Process()
        {
            return this.Generate.Process();
        }
    }
}
