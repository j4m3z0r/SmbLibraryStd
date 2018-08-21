/* Copyright (C) 2014 Tal Aloni <tal.aloni.il@gmail.com>. All rights reserved.
 * 
 * You can redistribute this program and/or modify it under the terms of
 * the GNU Lesser Public License as published by the Free Software Foundation,
 * either version 3 of the License, or (at your option) any later version.
 */
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace SmbLibraryStd.SMB1
{
    /// <summary>
    /// TRANS_SET_NMPIPE_STATE Request
    /// </summary>
    public class TransactionSetNamedPipeStateResponse : TransactionSubcommand
    {
        public override TransactionSubcommandName SubcommandName
        {
            get
            {
                return TransactionSubcommandName.TRANS_SET_NMPIPE_STATE;
            }
        }
    }
}
