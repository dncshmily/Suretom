﻿using Suretom.Client.Common;
using Suretom.Client.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.IService
{
    /// <summary>
    ///
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="StudentInfo"></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        HttpResult AddStudent(NameValueCollection paramValue);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        StudentInfo GetStudentList();
    }
}