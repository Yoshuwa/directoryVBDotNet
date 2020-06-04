Imports System.Data.SqlClient

Public Class CompanyData

    Public Shared Function SelectAll() As DataTable
        Dim connection As SqlConnection = directoryData.GetConnection
        Dim selectStatement As String _
            = "SELECT " _ 
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
            & ""
        Dim selectCommand As New SqlCommand(selectStatement, connection)
        selectCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        Try
            connection.Open()
            Dim reader As SqlDataReader = selectCommand.ExecuteReader()
            If reader.HasRows Then
                dt.Load(reader)
            End If
            reader.Close()
        Catch ex As SqlException
            Return dt
        Finally
            connection.Close()
        End Try
        Return dt
    End Function

    Public Shared Function Search(ByVal sField As String, ByVal sCondition As String, ByVal sValue As String) As DataTable
        Dim connection As SqlConnection = directoryData.GetConnection
        Dim selectStatement As String = Nothing
        If sCondition = "Contains" Then
            selectStatement _
                = "SELECT " _
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
                & "WHERE " _
                & "     (@CompanyID IS NULL OR @CompanyID = '' OR [Company].[CompanyID] LIKE '%' + LTRIM(RTRIM(@CompanyID)) + '%') " _
                & "AND   (@BusinessName IS NULL OR @BusinessName = '' OR [Company].[BusinessName] LIKE '%' + LTRIM(RTRIM(@BusinessName)) + '%') " _
                & "AND   (@Email IS NULL OR @Email = '' OR [Company].[Email] LIKE '%' + LTRIM(RTRIM(@Email)) + '%') " _
                & "AND   (@Phone IS NULL OR @Phone = '' OR [Company].[Phone] LIKE '%' + LTRIM(RTRIM(@Phone)) + '%') " _
                & "AND   (@Website IS NULL OR @Website = '' OR [Company].[Website] LIKE '%' + LTRIM(RTRIM(@Website)) + '%') " _
                & "AND   (@Rating IS NULL OR @Rating = '' OR [Company].[Rating] LIKE '%' + LTRIM(RTRIM(@Rating)) + '%') " _
                & "AND   (@Reviews IS NULL OR @Reviews = '' OR [Company].[Reviews] LIKE '%' + LTRIM(RTRIM(@Reviews)) + '%') " _
                & "AND   (@Latitude IS NULL OR @Latitude = '' OR [Company].[Latitude] LIKE '%' + LTRIM(RTRIM(@Latitude)) + '%') " _
                & "AND   (@Longitude IS NULL OR @Longitude = '' OR [Company].[Longitude] LIKE '%' + LTRIM(RTRIM(@Longitude)) + '%') " _
                & "AND   (@Category IS NULL OR @Category = '' OR [Company].[Category] LIKE '%' + LTRIM(RTRIM(@Category)) + '%') " _
                & ""
        ElseIf sCondition = "Equals" Then
            selectStatement _
                = "SELECT " _
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
                & "WHERE " _
                & "     (@CompanyID IS NULL OR @CompanyID = '' OR [Company].[CompanyID] = LTRIM(RTRIM(@CompanyID))) " _
                & "AND   (@BusinessName IS NULL OR @BusinessName = '' OR [Company].[BusinessName] = LTRIM(RTRIM(@BusinessName))) " _
                & "AND   (@Email IS NULL OR @Email = '' OR [Company].[Email] = LTRIM(RTRIM(@Email))) " _
                & "AND   (@Phone IS NULL OR @Phone = '' OR [Company].[Phone] = LTRIM(RTRIM(@Phone))) " _
                & "AND   (@Website IS NULL OR @Website = '' OR [Company].[Website] = LTRIM(RTRIM(@Website))) " _
                & "AND   (@Rating IS NULL OR @Rating = '' OR [Company].[Rating] = LTRIM(RTRIM(@Rating))) " _
                & "AND   (@Reviews IS NULL OR @Reviews = '' OR [Company].[Reviews] = LTRIM(RTRIM(@Reviews))) " _
                & "AND   (@Latitude IS NULL OR @Latitude = '' OR [Company].[Latitude] = LTRIM(RTRIM(@Latitude))) " _
                & "AND   (@Longitude IS NULL OR @Longitude = '' OR [Company].[Longitude] = LTRIM(RTRIM(@Longitude))) " _
                & "AND   (@Category IS NULL OR @Category = '' OR [Company].[Category] = LTRIM(RTRIM(@Category))) " _
                & ""
        ElseIf sCondition = "Starts with..." Then
            selectStatement _
                = "SELECT " _
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
                & "WHERE " _
                & "     (@CompanyID IS NULL OR @CompanyID = '' OR [Company].[CompanyID] LIKE LTRIM(RTRIM(@CompanyID)) + '%') " _
                & "AND   (@BusinessName IS NULL OR @BusinessName = '' OR [Company].[BusinessName] LIKE LTRIM(RTRIM(@BusinessName)) + '%') " _
                & "AND   (@Email IS NULL OR @Email = '' OR [Company].[Email] LIKE LTRIM(RTRIM(@Email)) + '%') " _
                & "AND   (@Phone IS NULL OR @Phone = '' OR [Company].[Phone] LIKE LTRIM(RTRIM(@Phone)) + '%') " _
                & "AND   (@Website IS NULL OR @Website = '' OR [Company].[Website] LIKE LTRIM(RTRIM(@Website)) + '%') " _
                & "AND   (@Rating IS NULL OR @Rating = '' OR [Company].[Rating] LIKE LTRIM(RTRIM(@Rating)) + '%') " _
                & "AND   (@Reviews IS NULL OR @Reviews = '' OR [Company].[Reviews] LIKE LTRIM(RTRIM(@Reviews)) + '%') " _
                & "AND   (@Latitude IS NULL OR @Latitude = '' OR [Company].[Latitude] LIKE LTRIM(RTRIM(@Latitude)) + '%') " _
                & "AND   (@Longitude IS NULL OR @Longitude = '' OR [Company].[Longitude] LIKE LTRIM(RTRIM(@Longitude)) + '%') " _
                & "AND   (@Category IS NULL OR @Category = '' OR [Company].[Category] LIKE LTRIM(RTRIM(@Category)) + '%') " _
                & ""
        ElseIf sCondition = "More than..." Then
            selectStatement _
                = "SELECT " _
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
                & "WHERE " _
                & "     (@CompanyID IS NULL OR @CompanyID = '' OR [Company].[CompanyID] > LTRIM(RTRIM(@CompanyID))) " _
                & "AND   (@BusinessName IS NULL OR @BusinessName = '' OR [Company].[BusinessName] > LTRIM(RTRIM(@BusinessName))) " _
                & "AND   (@Email IS NULL OR @Email = '' OR [Company].[Email] > LTRIM(RTRIM(@Email))) " _
                & "AND   (@Phone IS NULL OR @Phone = '' OR [Company].[Phone] > LTRIM(RTRIM(@Phone))) " _
                & "AND   (@Website IS NULL OR @Website = '' OR [Company].[Website] > LTRIM(RTRIM(@Website))) " _
                & "AND   (@Rating IS NULL OR @Rating = '' OR [Company].[Rating] > LTRIM(RTRIM(@Rating))) " _
                & "AND   (@Reviews IS NULL OR @Reviews = '' OR [Company].[Reviews] > LTRIM(RTRIM(@Reviews))) " _
                & "AND   (@Latitude IS NULL OR @Latitude = '' OR [Company].[Latitude] > LTRIM(RTRIM(@Latitude))) " _
                & "AND   (@Longitude IS NULL OR @Longitude = '' OR [Company].[Longitude] > LTRIM(RTRIM(@Longitude))) " _
                & "AND   (@Category IS NULL OR @Category = '' OR [Company].[Category] > LTRIM(RTRIM(@Category))) " _
                & ""
        ElseIf sCondition = "Less than..." Then
            selectStatement _
                = "SELECT " _
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
                & "WHERE " _
                & "     (@CompanyID IS NULL OR @CompanyID = '' OR [Company].[CompanyID] < LTRIM(RTRIM(@CompanyID))) " _
                & "AND   (@BusinessName IS NULL OR @BusinessName = '' OR [Company].[BusinessName] < LTRIM(RTRIM(@BusinessName))) " _
                & "AND   (@Email IS NULL OR @Email = '' OR [Company].[Email] < LTRIM(RTRIM(@Email))) " _
                & "AND   (@Phone IS NULL OR @Phone = '' OR [Company].[Phone] < LTRIM(RTRIM(@Phone))) " _
                & "AND   (@Website IS NULL OR @Website = '' OR [Company].[Website] < LTRIM(RTRIM(@Website))) " _
                & "AND   (@Rating IS NULL OR @Rating = '' OR [Company].[Rating] < LTRIM(RTRIM(@Rating))) " _
                & "AND   (@Reviews IS NULL OR @Reviews = '' OR [Company].[Reviews] < LTRIM(RTRIM(@Reviews))) " _
                & "AND   (@Latitude IS NULL OR @Latitude = '' OR [Company].[Latitude] < LTRIM(RTRIM(@Latitude))) " _
                & "AND   (@Longitude IS NULL OR @Longitude = '' OR [Company].[Longitude] < LTRIM(RTRIM(@Longitude))) " _
                & "AND   (@Category IS NULL OR @Category = '' OR [Company].[Category] < LTRIM(RTRIM(@Category))) " _
                & ""
        ElseIf sCondition = "Equal or more than..." Then
            selectStatement _
                = "SELECT " _
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
                & "WHERE " _
                & "     (@CompanyID IS NULL OR @CompanyID = '' OR [Company].[CompanyID] >= LTRIM(RTRIM(@CompanyID))) " _
                & "AND   (@BusinessName IS NULL OR @BusinessName = '' OR [Company].[BusinessName] >= LTRIM(RTRIM(@BusinessName))) " _
                & "AND   (@Email IS NULL OR @Email = '' OR [Company].[Email] >= LTRIM(RTRIM(@Email))) " _
                & "AND   (@Phone IS NULL OR @Phone = '' OR [Company].[Phone] >= LTRIM(RTRIM(@Phone))) " _
                & "AND   (@Website IS NULL OR @Website = '' OR [Company].[Website] >= LTRIM(RTRIM(@Website))) " _
                & "AND   (@Rating IS NULL OR @Rating = '' OR [Company].[Rating] >= LTRIM(RTRIM(@Rating))) " _
                & "AND   (@Reviews IS NULL OR @Reviews = '' OR [Company].[Reviews] >= LTRIM(RTRIM(@Reviews))) " _
                & "AND   (@Latitude IS NULL OR @Latitude = '' OR [Company].[Latitude] >= LTRIM(RTRIM(@Latitude))) " _
                & "AND   (@Longitude IS NULL OR @Longitude = '' OR [Company].[Longitude] >= LTRIM(RTRIM(@Longitude))) " _
                & "AND   (@Category IS NULL OR @Category = '' OR [Company].[Category] >= LTRIM(RTRIM(@Category))) " _
                & ""
        ElseIf sCondition = "Equal or less than..." Then
            selectStatement _
                = "SELECT " _
            & "     [Company].[CompanyID] " _
            & "    ,[Company].[BusinessName] " _
            & "    ,[Company].[Email] " _
            & "    ,[Company].[Phone] " _
            & "    ,[Company].[Website] " _
            & "    ,[Company].[Rating] " _
            & "    ,[Company].[Reviews] " _
            & "    ,[Company].[Latitude] " _
            & "    ,[Company].[Longitude] " _
            & "    ,[Company].[Category] " _
            & "FROM " _
            & "     [Company] " _
                & "WHERE " _
                & "     (@CompanyID IS NULL OR @CompanyID = '' OR [Company].[CompanyID] <= LTRIM(RTRIM(@CompanyID))) " _
                & "AND   (@BusinessName IS NULL OR @BusinessName = '' OR [Company].[BusinessName] <= LTRIM(RTRIM(@BusinessName))) " _
                & "AND   (@Email IS NULL OR @Email = '' OR [Company].[Email] <= LTRIM(RTRIM(@Email))) " _
                & "AND   (@Phone IS NULL OR @Phone = '' OR [Company].[Phone] <= LTRIM(RTRIM(@Phone))) " _
                & "AND   (@Website IS NULL OR @Website = '' OR [Company].[Website] <= LTRIM(RTRIM(@Website))) " _
                & "AND   (@Rating IS NULL OR @Rating = '' OR [Company].[Rating] <= LTRIM(RTRIM(@Rating))) " _
                & "AND   (@Reviews IS NULL OR @Reviews = '' OR [Company].[Reviews] <= LTRIM(RTRIM(@Reviews))) " _
                & "AND   (@Latitude IS NULL OR @Latitude = '' OR [Company].[Latitude] <= LTRIM(RTRIM(@Latitude))) " _
                & "AND   (@Longitude IS NULL OR @Longitude = '' OR [Company].[Longitude] <= LTRIM(RTRIM(@Longitude))) " _
                & "AND   (@Category IS NULL OR @Category = '' OR [Company].[Category] <= LTRIM(RTRIM(@Category))) " _
                & ""
        End If
        Dim selectCommand As New SqlCommand(selectStatement, connection)
        selectCommand.CommandType = CommandType.Text
        selectCommand.Parameters.AddWithValue("@CompanyID", IIf(sField = "Company I D", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@BusinessName", IIf(sField = "Business Name", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Email", IIf(sField = "Email", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Phone", IIf(sField = "Phone", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Website", IIf(sField = "Website", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Rating", IIf(sField = "Rating", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Reviews", IIf(sField = "Reviews", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Latitude", IIf(sField = "Latitude", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Longitude", IIf(sField = "Longitude", sValue, DBNull.Value))
        selectCommand.Parameters.AddWithValue("@Category", IIf(sField = "Category", sValue, DBNull.Value))
        Dim dt As New DataTable
        Try
            connection.Open()
            Dim reader As SqlDataReader = selectCommand.ExecuteReader()
            If reader.HasRows Then
                dt.Load(reader)
            End If
            reader.Close()
        Catch ex As SqlException
            Return dt
        Finally
            connection.Close()
        End Try
        Return dt
    End Function

    Public Shared Function Select_Record(ByVal CompanyPara As Company) As Company
        Dim Company As New Company
        Dim connection As SqlConnection = directoryData.GetConnection
        Dim selectStatement As String _
            = "SELECT " _ 
            & "     [CompanyID] " _
            & "    ,[BusinessName] " _
            & "    ,[Email] " _
            & "    ,[Phone] " _
            & "    ,[Website] " _
            & "    ,[Rating] " _
            & "    ,[Reviews] " _
            & "    ,[Latitude] " _
            & "    ,[Longitude] " _
            & "    ,[Category] " _
            & "FROM " _
            & "     [Company] " _
            & "WHERE " _
            & "     [CompanyID] = @CompanyID " _
            & ""
        Dim selectCommand As New SqlCommand(selectStatement, connection)
        selectCommand.CommandType = CommandType.Text
        selectCommand.Parameters.AddWithValue("@CompanyID", CompanyPara.CompanyID)
        Try
            connection.Open()
            Dim reader As SqlDataReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow)
            If reader.Read Then
                With Company
                    .CompanyID = System.Convert.ToInt32(reader("CompanyID"))
                    .BusinessName = If(IsDBNull(reader("BusinessName")), Nothing, reader("BusinessName").ToString)
                    .Email = If(IsDBNull(reader("Email")), Nothing, reader("Email").ToString)
                    .Phone = If(IsDBNull(reader("Phone")), Nothing, reader("Phone").ToString)
                    .Website = If(IsDBNull(reader("Website")), Nothing, reader("Website").ToString)
                    .Rating = If(IsDBNull(reader("Rating")), Nothing, CType(reader("Rating"), Int32?))
                    .Reviews = If(IsDBNull(reader("Reviews")), Nothing, CType(reader("Reviews"), Int32?))
                    .Latitude = If(IsDBNull(reader("Latitude")), Nothing, reader("Latitude").ToString)
                    .Longitude = If(IsDBNull(reader("Longitude")), Nothing, reader("Longitude").ToString)
                    .Category = If(IsDBNull(reader("Category")), Nothing, reader("Category").ToString)
                End With
            Else
                Company = Nothing
            End If
            reader.Close()
        Catch ex As SqlException
            Return Company
        Finally
            connection.Close()
        End Try
        Return Company
    End Function

    Public Shared Function Add(ByVal Company As Company) As Boolean
        Dim connection As SqlConnection = directoryData.GetConnection
        Dim insertStatement As String _
            = "INSERT " _ 
            & "     [Company] " _
            & "     ( " _
            & "     [BusinessName] " _
            & "    ,[Email] " _
            & "    ,[Phone] " _
            & "    ,[Website] " _
            & "    ,[Rating] " _
            & "    ,[Reviews] " _
            & "    ,[Latitude] " _
            & "    ,[Longitude] " _
            & "    ,[Category] " _
            & "     ) " _
            & "VALUES " _ 
            & "     ( " _
            & "     @BusinessName " _
            & "    ,@Email " _
            & "    ,@Phone " _
            & "    ,@Website " _
            & "    ,@Rating " _
            & "    ,@Reviews " _
            & "    ,@Latitude " _
            & "    ,@Longitude " _
            & "    ,@Category " _
            & "     ) " _
            & ""
        Dim insertCommand As New SqlCommand(insertStatement, connection)
        insertCommand.CommandType = CommandType.Text
        insertCommand.Parameters.AddWithValue("@BusinessName", IIf(Not IsNothing(Company.BusinessName), Company.BusinessName, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Email", IIf(Not IsNothing(Company.Email), Company.Email, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Phone", IIf(Not IsNothing(Company.Phone), Company.Phone, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Website", IIf(Not IsNothing(Company.Website), Company.Website, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Rating", IIf(Company.Rating.HasValue, Company.Rating, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Reviews", IIf(Company.Reviews.HasValue, Company.Reviews, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Latitude", IIf(Not IsNothing(Company.Latitude), Company.Latitude, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Longitude", IIf(Not IsNothing(Company.Longitude), Company.Longitude, DBNull.Value))
        insertCommand.Parameters.AddWithValue("@Category", IIf(Not IsNothing(Company.Category), Company.Category, DBNull.Value))
        Try
            connection.Open()
            Dim count As Integer = insertCommand.ExecuteNonQuery()
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            Return False
        Finally
            connection.Close()
        End Try
        Return True
    End Function

    Public Shared Function Update(ByVal CompanyOld As Company, _
           ByVal CompanyNew As Company) As Boolean
        Dim connection As SqlConnection = directoryData.GetConnection
        Dim updateStatement As String _
            = "UPDATE " _  
            & "     [Company] " _
            & "SET " _
            & "     [BusinessName] = @NewBusinessName " _
            & "    ,[Email] = @NewEmail " _
            & "    ,[Phone] = @NewPhone " _
            & "    ,[Website] = @NewWebsite " _
            & "    ,[Rating] = @NewRating " _
            & "    ,[Reviews] = @NewReviews " _
            & "    ,[Latitude] = @NewLatitude " _
            & "    ,[Longitude] = @NewLongitude " _
            & "    ,[Category] = @NewCategory " _
            & "WHERE " _
            & "     [CompanyID] = @OldCompanyID " _
            & " AND ((@OldBusinessName IS NULL AND [BusinessName] IS NULL) OR [BusinessName] = @OldBusinessName) " _
            & " AND ((@OldEmail IS NULL AND [Email] IS NULL) OR [Email] = @OldEmail) " _
            & " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " _
            & " AND ((@OldWebsite IS NULL AND [Website] IS NULL) OR [Website] = @OldWebsite) " _
            & " AND ((@OldRating IS NULL AND [Rating] IS NULL) OR [Rating] = @OldRating) " _
            & " AND ((@OldReviews IS NULL AND [Reviews] IS NULL) OR [Reviews] = @OldReviews) " _
            & " AND ((@OldLatitude IS NULL AND [Latitude] IS NULL) OR [Latitude] = @OldLatitude) " _
            & " AND ((@OldLongitude IS NULL AND [Longitude] IS NULL) OR [Longitude] = @OldLongitude) " _
            & " AND ((@OldCategory IS NULL AND [Category] IS NULL) OR [Category] = @OldCategory) " _
            & ""
        Dim updateCommand As New SqlCommand(updateStatement, connection)
        updateCommand.CommandType = CommandType.Text
        updateCommand.Parameters.AddWithValue("@NewBusinessName", IIf(Not IsNothing(CompanyNew.BusinessName), CompanyNew.BusinessName, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewEmail", IIf(Not IsNothing(CompanyNew.Email), CompanyNew.Email, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewPhone", IIf(Not IsNothing(CompanyNew.Phone), CompanyNew.Phone, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewWebsite", IIf(Not IsNothing(CompanyNew.Website), CompanyNew.Website, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewRating", IIf(CompanyNew.Rating.HasValue, CompanyNew.Rating, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewReviews", IIf(CompanyNew.Reviews.HasValue, CompanyNew.Reviews, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewLatitude", IIf(Not IsNothing(CompanyNew.Latitude), CompanyNew.Latitude, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewLongitude", IIf(Not IsNothing(CompanyNew.Longitude), CompanyNew.Longitude, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@NewCategory", IIf(Not IsNothing(CompanyNew.Category), CompanyNew.Category, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldCompanyID", CompanyOld.CompanyID)
        updateCommand.Parameters.AddWithValue("@OldBusinessName", IIf(Not IsNothing(CompanyOld.BusinessName), CompanyOld.BusinessName, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldEmail", IIf(Not IsNothing(CompanyOld.Email), CompanyOld.Email, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldPhone", IIf(Not IsNothing(CompanyOld.Phone), CompanyOld.Phone, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldWebsite", IIf(Not IsNothing(CompanyOld.Website), CompanyOld.Website, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldRating", IIf(CompanyOld.Rating.HasValue, CompanyOld.Rating, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldReviews", IIf(CompanyOld.Reviews.HasValue, CompanyOld.Reviews, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldLatitude", IIf(Not IsNothing(CompanyOld.Latitude), CompanyOld.Latitude, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldLongitude", IIf(Not IsNothing(CompanyOld.Longitude), CompanyOld.Longitude, DBNull.Value))
        updateCommand.Parameters.AddWithValue("@OldCategory", IIf(Not IsNothing(CompanyOld.Category), CompanyOld.Category, DBNull.Value))
        Try
            connection.Open()
            Dim count As Integer = updateCommand.ExecuteNonQuery()
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            Return False
        Finally
            connection.Close()
        End Try
        Return True
    End Function

    Public Shared Function Delete(ByVal Company As Company) As Boolean
        Dim connection As SqlConnection = directoryData.GetConnection
        Dim deleteStatement As String _
            = "DELETE FROM " _  
            & "     [Company] " _
            & "WHERE " _
            & "     [CompanyID] = @OldCompanyID " _
            & " AND ((@OldBusinessName IS NULL AND [BusinessName] IS NULL) OR [BusinessName] = @OldBusinessName) " _
            & " AND ((@OldEmail IS NULL AND [Email] IS NULL) OR [Email] = @OldEmail) " _
            & " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " _
            & " AND ((@OldWebsite IS NULL AND [Website] IS NULL) OR [Website] = @OldWebsite) " _
            & " AND ((@OldRating IS NULL AND [Rating] IS NULL) OR [Rating] = @OldRating) " _
            & " AND ((@OldReviews IS NULL AND [Reviews] IS NULL) OR [Reviews] = @OldReviews) " _
            & " AND ((@OldLatitude IS NULL AND [Latitude] IS NULL) OR [Latitude] = @OldLatitude) " _
            & " AND ((@OldLongitude IS NULL AND [Longitude] IS NULL) OR [Longitude] = @OldLongitude) " _
            & " AND ((@OldCategory IS NULL AND [Category] IS NULL) OR [Category] = @OldCategory) " _
            & ""
        Dim deleteCommand As New SqlCommand(deleteStatement, connection)
        deleteCommand.CommandType = CommandType.Text
        deleteCommand.Parameters.AddWithValue("@OldCompanyID", Company.CompanyID)
        deleteCommand.Parameters.AddWithValue("@OldBusinessName", IIf(Not IsNothing(Company.BusinessName), Company.BusinessName, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldEmail", IIf(Not IsNothing(Company.Email), Company.Email, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldPhone", IIf(Not IsNothing(Company.Phone), Company.Phone, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldWebsite", IIf(Not IsNothing(Company.Website), Company.Website, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldRating", IIf(Company.Rating.HasValue, Company.Rating, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldReviews", IIf(Company.Reviews.HasValue, Company.Reviews, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldLatitude", IIf(Not IsNothing(Company.Latitude), Company.Latitude, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldLongitude", IIf(Not IsNothing(Company.Longitude), Company.Longitude, DBNull.Value))
        deleteCommand.Parameters.AddWithValue("@OldCategory", IIf(Not IsNothing(Company.Category), Company.Category, DBNull.Value))
        Try
            connection.Open()
            Dim count As Integer = deleteCommand.ExecuteNonQuery()
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            Return False
        Finally
            connection.Close()
        End Try
        Return True
    End Function

End Class
 
