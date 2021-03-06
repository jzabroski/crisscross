﻿// CrissCross - alternative user interface for running SSRS reports
// Copyright (C) 2011 Ian Richardson
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rws = CrissCrossLib.ReportWebService;

namespace CrissCrossLib.Caching
{
    public class CrcCacheManager
    {
        private static CrcCacheManager ms_instance = null;
        
        public static CrcCacheManager Instance
        {
            get
            {
                if (ms_instance == null)
                    ms_instance = new CrcCacheManager();
                return ms_instance;
            }
        }

        public CrcCacheManager()
        {
            AllReportsCacheByUsername = new TimedCache<rws.CatalogItem[]>("allrep", 30, 45);
            AllReportsHierarchicalCacheByUsername = new TimedCache<CrissCrossLib.Hierarchical.CrcReportFolder>("allrephier", 30, 45);
            PopularReportsCacheByUsername = new TimedCache<rws.CatalogItem[]>("poprep", 30, 45);
            GlobalPopularReportsCacheByUsername = new TimedCache<rws.CatalogItem[]>("globpoprep", 30, 45);
        }

        public virtual TimedCache<rws.CatalogItem[]> AllReportsCacheByUsername { get; set; }
        public virtual TimedCache<CrissCrossLib.Hierarchical.CrcReportFolder> AllReportsHierarchicalCacheByUsername { get; set; }
        public virtual TimedCache<rws.CatalogItem[]> PopularReportsCacheByUsername { get; set; }
        public virtual TimedCache<rws.CatalogItem[]> GlobalPopularReportsCacheByUsername { get; set; }
        
    }
}
