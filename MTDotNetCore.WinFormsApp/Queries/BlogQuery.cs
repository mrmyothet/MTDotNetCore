﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.WinFormsApp.Queries;

internal class BlogQuery
{
    public static string InsertQuery = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([BlogTitle]
                           ,[BlogAuthor]
                           ,[BlogContent])
                     VALUES
                           (@BlogTitle
                           ,@BlogAuthor
                           ,@BlogContent)";

    public static string SelectQuery = @"SELECT [BlogId]
                                      ,[BlogTitle]
                                      ,[BlogAuthor]
                                      ,[BlogContent]
                                  FROM [dbo].[Tbl_Blog]";

    public static string DeleteQuery = "DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

}
