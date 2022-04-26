<HTML>
<HEAD>
<TITLE>iPayment Error Page</TITLE>

</HEAD>

<body bgcolor=#ffffdd text=#000000 link=#333333 alink=#333333 vlink=#333333>

<form name="iPaymentErrorPage" method="POST" action="">
<table cellspacing=0 cellpadding=10 border=1 bgcolor=#ffffff>

     <tr>
        <td ALIGN="LEFT" COLSPAN="5">
            <font SIZE="+1"><strong>Error Occured</strong></font>
        </td>
    </tr>
<%
if(request.getParameter("errCode")!=null)
{
%>
	<tr>
        <td ALIGN="LEFT">
            <b>Error Code : </b>
        </td>
        <td><%=request.getParameter("errCode")%></td>
    </tr>
<%
}
%>
<%
if(request.getParameter("errMessage")!=null)
{
%>
	<tr>
        <td ALIGN="LEFT">
            <b>Error Message : </b>
        </td>
        <td><%=request.getParameter("errMessage")%></td>
    </tr>
<%
}
%>
</table>
</form>
</HTML>
