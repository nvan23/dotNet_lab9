﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfrStudent.aspx.cs" Inherits="Student.wfrStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grvStudent" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="4" DataKeyNames="MaSV" ForeColor="#333333" GridLines="None" Height="428px" Width="1191px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="MaSV" HeaderText="Mã Số Sinh Viên" />
                <asp:BoundField DataField="TenSV" HeaderText="Họ Tên" />
                <asp:BoundField DataField="Phai" HeaderText="Phái" SortExpression="Phai" />
                <asp:BoundField DataField="Lop" HeaderText="Lớp" SortExpression="Lop" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" BorderStyle="None" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" Height="5px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
