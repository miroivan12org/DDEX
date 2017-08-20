﻿using Business.DDEXFactory.Intefaces;
using Business.DDEXFactory.Interfaces;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.Collections.Generic;

namespace Business.DDEXSchemaERN_382.Entities
{
    public class TrackModel: BindableModel
    {
        [NotNull]
        public int Ordinal{ get { return Get<int>(); } set { Set(value); } }
        [NotNull]
        public string ISRC { get { return Get<string>(); } set { Set(value); } }
        [NotNull]
        public string Title { get { return Get<string>(); } set { Set(value); } }
        public string Genre { get { return Get<string>(); } set { Set(value); } }
        public string SubGenre { get { return Get<string>(); } set { Set(value); } }
        public string PLineText { get { return Get<string>(); } set { Set(value); } }
        public string PLineReleaseYear { get { return Get<string>(); } set { Set(value); } }
        public string ResourceReleaseDate { get { return Get<string>(); } set { Set(value); } }
        public string CLineText { get { return Get<string>(); } set { Set(value); } }
        public string CLineReleaseYear { get { return Get<string>(); } set { Set(value); } }
        public string MainArtist { get { return Get<string>(); } set { Set(value); } }
        [NotNull]
        public int DurationMin { get { return Get<int>(); } set { Set(value); } }
        [NotNull]
        public int DurationSec { get { return Get<int>(); } set { Set(value); } }        
        public string Producer { get { return Get<string>(); } set { Set(value); } }

        #region Technical details

        public AudioCodecType AudioCodec { get { return Get<AudioCodecType>(); } set { Set(value); } }
        public int NumberOfChannels { get { return Get<int>(); } set { Set(value); } }
        public decimal SamplingRate { get { return Get<decimal>(); } set { Set(value); } }
        public int BitsPerSample { get { return Get<int>(); } set { Set(value); } }
        public string TrackFullFileName { get { return Get<string>(); } set { Set(value); } }
        public string FileName { get { return Get<string>(); } set { Set(value); } }
        public string FilePath { get { return Get<string>(); } set { Set(value); } }
        public string FileHashSum_Materialized { get { return Get<string>(); } set { Set(value); } }

        public string GetFullFileNameFromRelativePathAndFileName(string rootDirectory, string relativePath, string fileName)
        {
            string ret = null;

            if (relativePath != null && fileName != null)
            {
                string dir = rootDirectory;
                ret = dir + @"\" + relativePath.TrimEnd('/') + @"\" + fileName;
            }

            return ret;
        }
        public void ComputeMaterialized()
        {
            if (System.IO.File.Exists(TrackFullFileName))
            {
                FileHashSum_Materialized = DDEXFactory.Helpers.FilesHelper.GetMD5HashSum(TrackFullFileName);
            }

        }

        #endregion

        public string Contributor1 { get { return Get<string>(); } set { Set(value); } }
        public string Contributor1Role { get { return Get<string>(); } set { Set(value); } }
        public string Contributor2 { get { return Get<string>(); } set { Set(value); } }
        public string Contributor2Role { get { return Get<string>(); } set { Set(value); } }
        public string Contributor3 { get { return Get<string>(); } set { Set(value); } }
        public string Contributor3Role { get { return Get<string>(); } set { Set(value); } }
        public string Contributor4 { get { return Get<string>(); } set { Set(value); } }
        public string Contributor4Role { get { return Get<string>(); } set { Set(value); } }
        public string Contributor5 { get { return Get<string>(); } set { Set(value); } }
        public string Contributor5Role { get { return Get<string>(); } set { Set(value); } }
        public string Contributor6 { get { return Get<string>(); } set { Set(value); } }
        public string Contributor6Role { get { return Get<string>(); } set { Set(value); } }

        public List<Tuple<string, string>> IndirectContributors
        {
            get
            {
                var lsIndirectContributors = new List<Tuple<string, string>>();

                if (Contributor1 != null && Contributor1 != "" && Contributor1Role != null && Contributor1Role != "")
                    lsIndirectContributors.Add(new Tuple<string, string>(Contributor1, Contributor1Role));
                if (Contributor2 != null && Contributor2 != "" && Contributor2Role != null && Contributor2Role != "")
                    lsIndirectContributors.Add(new Tuple<string, string>(Contributor2, Contributor2Role));
                if (Contributor3 != null && Contributor3 != "" && Contributor3Role != null && Contributor3Role != "")
                    lsIndirectContributors.Add(new Tuple<string, string>(Contributor3, Contributor3Role));
                if (Contributor4 != null && Contributor4 != "" && Contributor4Role != null && Contributor4Role != "")
                    lsIndirectContributors.Add(new Tuple<string, string>(Contributor4, Contributor4Role));
                if (Contributor5 != null && Contributor5 != "" && Contributor5Role != null && Contributor5Role != "")
                    lsIndirectContributors.Add(new Tuple<string, string>(Contributor5, Contributor5Role));
                if (Contributor6 != null && Contributor6 != "" && Contributor6Role != null && Contributor6Role != "")
                    lsIndirectContributors.Add(new Tuple<string, string>(Contributor6, Contributor6Role));

                return lsIndirectContributors;
            }
        }

        public override bool IsValid(out string message)
        {

            return base.IsValid(out message);
        }
    }
}
