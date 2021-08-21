#region "Imports"

using System.Collections;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for storing Fraud Protection Services
	/// XML response message after parsing them.
	/// </summary>
	/// <remarks>If the VERBOSITY set for the transaction is HIGH, 
	/// Fraud Protection Services return FPS_PREXMLDATA and/or 
	/// FPS_POSTXMLDATA response messages. This are xml messages.
	/// <para>While parsing the response, these xml messages are parsed 
	/// and populated into Rule data objects. These Rule objects are rules applied 
	/// by the Fraud Protection Services.. FpsXmlData is the container class 
	/// for all such rules.</para>
	/// <para>FpsXmlData data objects instances are contained in 
	/// FraduResponse and populated if obtained.</para>
	/// <seealso cref="FraudResponse"/>
	/// <seealso cref="Rule"/>
	/// <seealso cref="RuleParameter"/>
	/// </remarks>
	/// <example>
	/// Following example shows how to obtained and use FpsXmlData.
	/// <code lang="C#" escaped="false">
	///	    ..............................
	///	     // Resp is the Response object 
	///	    // obtained after submitting the transaction.
	///	    ..............................
	///	    
	///	    FpsXmlData mFpsXmlData;
	///	    ArrayList mRules = new ArrayList();
	///	    Rule mRuleType;
	///	    RuleParameter mRuleVendorParamType;
	///	    ArrayList mRuleVendorParams = new ArrayList();
	///	    int i;
	///	    
	///	    if(Resp != null)
	///	    {
	///			// Get the Fraud Response
	///	    	FraudResponse FraudResp = Resp.FraudResult;
	///		
	///	    	if(FraudResp == null)
	///	    	{
	///	    		return;
	///	    	}
	///	    
	///	    FpsPreXmlData = FraudResp.Fps_PreXmlData;
	///	    mRules = FpsPreXmlData.Rules;
	///	    foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
	///	    {
	///	    	mRuleType = tempLoopVar_mRuleType;
	///	    	
	///	    	Console.WriteLine("ACTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Action);
	///	    	Console.WriteLine("NUM FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Num);
	///	    	Console.WriteLine("RULEALIAS FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleAlias);
	///	    	Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleDescription);
	///	    	Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId+ mRuleType.TriggeredMessage);
	///	    	
	///	    	mRuleVendorParams = mRuleType.RuleVendorParms;
	///	    	i=0;
	///	    	foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
	///	    	{
	///	    		mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
	///	    		Console.WriteLine("Name_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Name);
	///	    		Console.WriteLine("Num_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Num);
	///	    		Console.WriteLine("Type_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Type);
	///	    		Console.WriteLine("Value_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Value);
	///	    	   i++;
	///	    	}
	///	    }
	///	    
	///	    FpsPreXmlData = mFraudResp.Fps_PostXmlData;
	///	    mRules = FpsPreXmlData.Rules;
	///	    foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
	///	    {
	///	    	mRuleType = tempLoopVar_mRuleType;
	///	    	
	///	    	Console.WriteLine("RuleId"+ mRuleType.RuleId);
	///	    	Console.WriteLine("ACTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Action);
	///	    	Console.WriteLine("NUM FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Num);
	///	    	Console.WriteLine("RULEALIAS FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleAlias);
	///	    	Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleDescription);
	///	    	Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId+ mRuleType.TriggeredMessage);
	///	    	
	///	    	mRuleVendorParams = mRuleType.RuleVendorParms;
	///	    	i=0;
	///	    	foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
	///	    	{
	///	    		mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
	///	    		Console.WriteLine("NAME_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Name);
	///	    		Console.WriteLine("NUM "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Num);
	///	    		Console.WriteLine("TYPE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Type);
	///	    		Console.WriteLine("VALUE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Value);
	///	    	    i++;
	///	    	}
	///	    }
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///	    ..............................
	///	    ' Resp is the Response object 
	///	    ' obtained after submitting the transaction.
	///	    ..............................
	///	    
	///	    Dim FpsXmlData As FpsXmlData
	///	    Dim Rules As New ArrayList
	///	    Dim RuleType As Rule
	///	    Dim RuleVendorParamType As RuleParameter
	///	    Dim RuleVendorParams As New ArrayList
	///	    
	///	    if(Resp != null)
	///	    {
	///		' Get the Fraud Response
	///	    	Dim FraudResp As FraudResponse = Resp.FraudResult
	///		
	///	    	If Object.Equals(FraudResp, Nothing) Then
	///	    		return
	///	    	EndIf
	///	    
	///	    FpsPreXmlData = FraudResp.Fps_PreXmlData
	///	    Rules = FpsPreXmlData.Rules()
	///	    Dim iCount As Integer
	///	    iCount = 0
	///	    For Each RuleType In Rules
	///	    
	///	        Console.WriteLine("ACTION FOR RULE ID - " + RuleType.RuleId + RuleType.Action)
	///	        Console.WriteLine("NUM FOR RULE ID - " + RuleType.RuleId + RuleType.Num)
	///	        Console.WriteLine("RULEALIAS FOR RULE ID - " + RuleType.RuleId + RuleType.RuleAlias)
	///	        Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId + RuleType.RuleDescription)
	///	        Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId + RuleType.TriggeredMessage)
	///	    
	///	        RuleVendorParams = RuleType.RuleVendorParms
	///	        For Each RuleVendorParamType In RuleVendorParams
	///	            Console.WriteLine("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Name)
	///	            Console.WriteLine("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Num)
	///	            Console.WriteLine("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Type)
	///	            Console.WriteLine("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Value)
	///	            iCount = iCount + 1
	///	        Next
	///	    Next
	///	    
	///	    FpsPostXmlData = FraudResp.Fps_PostXmlData
	///	    Rules = FpsPostXmlData.Rules()
	///	    For Each RuleType In Rules
	///	    
	///	        Console.WriteLine("RuleId" + RuleType.RuleId)
	///	        Console.WriteLine("ACTION FOR RULE ID - " + RuleType.RuleId + RuleType.Action)
	///	        Console.WriteLine("NUM FOR RULE ID - " + RuleType.RuleId + RuleType.Num)
	///	        Console.WriteLine("RULEALIAS FOR RULE ID - " + RuleType.RuleId + RuleType.RuleAlias)
	///	        Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId + RuleType.RuleDescription)
	///	        Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId + RuleType.TriggeredMessage)
	///	    
	///	        RuleVendorParams = RuleType.RuleVendorParms
	///	    
	///	        iCount = 0
	///	        For Each RuleVendorParamType In RuleVendorParams
	///	            Console.WriteLine("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Name)
	///	            Console.WriteLine("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Num)
	///	            Console.WriteLine("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Type)
	///	            Console.WriteLine("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Value)
	///	            iCount = iCount + 1
	///	        Next
	///	    Next
	/// </code>
	/// </example>
	public class FpsXmlData
	{
		#region "Member Variables"

		/// <summary>
		/// Holds applied Rules.
		/// </summary>
		private ArrayList mRules;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets the Rule list
		/// </summary>
		/// <remarks>If the VERBOSITY set for the transaction is HIGH, 
		/// Fraud Protection Services return FPS_PREXMLDATA and/or 
		/// FPS_POSTXMLDATA response messages. This are xml messages.
		/// <para>While parsing the response, these xml messages are parsed 
		/// and populated into Rule data objects. These Rule objects are rules applied 
		/// by the Fraud Protection Services.. FpsXmlData is the container class 
		/// for all such rules.</para>
		/// <para>FpsXmlData data objects instances are contained in 
		/// FraduResponse and populated if obtained.</para>
		/// <seealso cref="FraudResponse"/>
		/// <seealso cref="Rule"/>
		/// <seealso cref="RuleParameter"/>
		/// </remarks>
		/// <example>
		/// Following example shows how to obtained and use FpsXmlData.
		/// <code lang="C#" escaped="false">
		///	    ..............................
		///	     // Resp is the Response object 
		///	    // obtained after submitting the transaction.
		///	    ..............................
		///	    
		///	    FpsXmlData mFpsXmlData;
		///	    ArrayList mRules = new ArrayList();
		///	    Rule mRuleType;
		///	    RuleParameter mRuleVendorParamType;
		///	    ArrayList mRuleVendorParams = new ArrayList();
		///	    int i;
		///	    
		///	    if(Resp != null)
		///	    {
		///			// Get the Fraud Response
		///	    	FraudResponse FraudResp = Resp.FraudResult;
		///		
		///	    	if(FraudResp == null)
		///	    	{
		///	    		return;
		///	    	}
		///	    
		///	    FpsPreXmlData = FraudResp.Fps_PreXmlData;
		///	    mRules = FpsPreXmlData.Rules;
		///	    foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
		///	    {
		///	    	mRuleType = tempLoopVar_mRuleType;
		///	    	
		///	    	Console.WriteLine("ACTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Action);
		///	    	Console.WriteLine("NUM FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Num);
		///	    	Console.WriteLine("RULEALIAS FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleAlias);
		///	    	Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleDescription);
		///	    	Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId+ mRuleType.TriggeredMessage);
		///	    	
		///	    	mRuleVendorParams = mRuleType.RuleVendorParms;
		///	    	i=0;
		///	    	foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
		///	    	{
		///	    		mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
		///	    		Console.WriteLine("Name_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Name);
		///	    		Console.WriteLine("Num_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Num);
		///	    		Console.WriteLine("Type_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Type);
		///	    		Console.WriteLine("Value_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Value);
		///	    	   i++;
		///	    	}
		///	    }
		///	    
		///	    FpsPreXmlData = mFraudResp.Fps_PostXmlData;
		///	    mRules = FpsPreXmlData.Rules;
		///	    foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
		///	    {
		///	    	mRuleType = tempLoopVar_mRuleType;
		///	    	
		///	    	Console.WriteLine("RuleId"+ mRuleType.RuleId);
		///	    	Console.WriteLine("ACTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Action);
		///	    	Console.WriteLine("NUM FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Num);
		///	    	Console.WriteLine("RULEALIAS FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleAlias);
		///	    	Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleDescription);
		///	    	Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId+ mRuleType.TriggeredMessage);
		///	    	
		///	    	mRuleVendorParams = mRuleType.RuleVendorParms;
		///	    	i=0;
		///	    	foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
		///	    	{
		///	    		mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
		///	    		Console.WriteLine("NAME_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Name);
		///	    		Console.WriteLine("NUM "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Num);
		///	    		Console.WriteLine("TYPE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Type);
		///	    		Console.WriteLine("VALUE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Value);
		///	    	    i++;
		///	    	}
		///	    }
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///	    ..............................
		///	    ' Resp is the Response object 
		///	    ' obtained after submitting the transaction.
		///	    ..............................
		///	    
		///	    Dim FpsXmlData As FpsXmlData
		///	    Dim Rules As New ArrayList
		///	    Dim RuleType As Rule
		///	    Dim RuleVendorParamType As RuleParameter
		///	    Dim RuleVendorParams As New ArrayList
		///	    
		///	    if(Resp != null)
		///	    {
		///		' Get the Fraud Response
		///	    	Dim FraudResp As FraudResponse = Resp.FraudResult
		///		
		///	    	If Object.Equals(FraudResp, Nothing) Then
		///	    		return
		///	    	EndIf
		///	    
		///	    FpsPreXmlData = FraudResp.Fps_PreXmlData
		///	    Rules = FpsPreXmlData.Rules()
		///	    Dim iCount As Integer
		///	    iCount = 0
		///	    For Each RuleType In Rules
		///	    
		///	        Console.WriteLine("ACTION FOR RULE ID - " + RuleType.RuleId + RuleType.Action)
		///	        Console.WriteLine("NUM FOR RULE ID - " + RuleType.RuleId + RuleType.Num)
		///	        Console.WriteLine("RULEALIAS FOR RULE ID - " + RuleType.RuleId + RuleType.RuleAlias)
		///	        Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId + RuleType.RuleDescription)
		///	        Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId + RuleType.TriggeredMessage)
		///	    
		///	        RuleVendorParams = RuleType.RuleVendorParms
		///	        For Each RuleVendorParamType In RuleVendorParams
		///	            Console.WriteLine("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Name)
		///	            Console.WriteLine("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Num)
		///	            Console.WriteLine("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Type)
		///	            Console.WriteLine("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Value)
		///	            iCount = iCount + 1
		///	        Next
		///	    Next
		///	    
		///	    FpsPostXmlData = FraudResp.Fps_PostXmlData
		///	    Rules = FpsPostXmlData.Rules()
		///	    For Each RuleType In Rules
		///	    
		///	        Console.WriteLine("RuleId" + RuleType.RuleId)
		///	        Console.WriteLine("ACTION FOR RULE ID - " + RuleType.RuleId + RuleType.Action)
		///	        Console.WriteLine("NUM FOR RULE ID - " + RuleType.RuleId + RuleType.Num)
		///	        Console.WriteLine("RULEALIAS FOR RULE ID - " + RuleType.RuleId + RuleType.RuleAlias)
		///	        Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId + RuleType.RuleDescription)
		///	        Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId + RuleType.TriggeredMessage)
		///	    
		///	        RuleVendorParams = RuleType.RuleVendorParms
		///	    
		///	        iCount = 0
		///	        For Each RuleVendorParamType In RuleVendorParams
		///	            Console.WriteLine("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Name)
		///	            Console.WriteLine("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Num)
		///	            Console.WriteLine("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Type)
		///	            Console.WriteLine("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Value)
		///	            iCount = iCount + 1
		///	        Next
		///	    Next
		/// </code>
		/// </example>
		public ArrayList Rules
		{
			get { return mRules; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for FpsXmlData
		/// </summary>
		/// <remarks>If the VERBOSITY set for the transaction is HIGH, 
		/// Fraud Protection Services return FPS_PREXMLDATA and/or 
		/// FPS_POSTXMLDATA response messages. This are xml messages.
		/// <para>While parsing the response, these xml messages are parsed 
		/// and populated into Rule data objects. These Rule objects are rules applied 
		/// by the Fraud Protection Services.. FpsXmlData is the container class 
		/// for all such rules.</para>
		/// <para>FpsXmlData data objects instances are contained in 
		/// FraduResponse and populated if obtained.</para>
		/// <seealso cref="FraudResponse"/>
		/// <seealso cref="Rule"/>
		/// <seealso cref="RuleParameter"/>
		/// </remarks>
		/// <example>
		/// Following example shows how to obtained and use FpsXmlData.
		/// <code lang="C#" escaped="false">
		///	    ..............................
		///	     // Resp is the Response object 
		///	    // obtained after submitting the transaction.
		///	    ..............................
		///	    
		///	    FpsXmlData mFpsXmlData;
		///	    ArrayList mRules = new ArrayList();
		///	    Rule mRuleType;
		///	    RuleParameter mRuleVendorParamType;
		///	    ArrayList mRuleVendorParams = new ArrayList();
		///	    int i;
		///	    
		///	    if(Resp != null)
		///	    {
		///			// Get the Fraud Response
		///	    	FraudResponse FraudResp = Resp.FraudResult;
		///		
		///	    	if(FraudResp == null)
		///	    	{
		///	    		return;
		///	    	}
		///	    
		///	    FpsPreXmlData = FraudResp.Fps_PreXmlData;
		///	    mRules = FpsPreXmlData.Rules;
		///	    foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
		///	    {
		///	    	mRuleType = tempLoopVar_mRuleType;
		///	    	
		///	    	Console.WriteLine("ACTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Action);
		///	    	Console.WriteLine("NUM FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Num);
		///	    	Console.WriteLine("RULEALIAS FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleAlias);
		///	    	Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleDescription);
		///	    	Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId+ mRuleType.TriggeredMessage);
		///	    	
		///	    	mRuleVendorParams = mRuleType.RuleVendorParms;
		///	    	i=0;
		///	    	foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
		///	    	{
		///	    		mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
		///	    		Console.WriteLine("Name_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Name);
		///	    		Console.WriteLine("Num_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Num);
		///	    		Console.WriteLine("Type_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Type);
		///	    		Console.WriteLine("Value_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Value);
		///	    	   i++;
		///	    	}
		///	    }
		///	    
		///	    FpsPreXmlData = mFraudResp.Fps_PostXmlData;
		///	    mRules = FpsPreXmlData.Rules;
		///	    foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
		///	    {
		///	    	mRuleType = tempLoopVar_mRuleType;
		///	    	
		///	    	Console.WriteLine("RuleId"+ mRuleType.RuleId);
		///	    	Console.WriteLine("ACTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Action);
		///	    	Console.WriteLine("NUM FOR RULE ID - " + mRuleType.RuleId+ mRuleType.Num);
		///	    	Console.WriteLine("RULEALIAS FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleAlias);
		///	    	Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId+ mRuleType.RuleDescription);
		///	    	Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId+ mRuleType.TriggeredMessage);
		///	    	
		///	    	mRuleVendorParams = mRuleType.RuleVendorParms;
		///	    	i=0;
		///	    	foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
		///	    	{
		///	    		mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
		///	    		Console.WriteLine("NAME_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Name);
		///	    		Console.WriteLine("NUM "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Num);
		///	    		Console.WriteLine("TYPE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Type);
		///	    		Console.WriteLine("VALUE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId+ mRuleVendorParamType.Value);
		///	    	    i++;
		///	    	}
		///	    }
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///	    ..............................
		///	    ' Resp is the Response object 
		///	    ' obtained after submitting the transaction.
		///	    ..............................
		///	    
		///	    Dim FpsXmlData As FpsXmlData
		///	    Dim Rules As New ArrayList
		///	    Dim RuleType As Rule
		///	    Dim RuleVendorParamType As RuleParameter
		///	    Dim RuleVendorParams As New ArrayList
		///	    
		///	    if(Resp != null)
		///	    {
		///		' Get the Fraud Response
		///	    	Dim FraudResp As FraudResponse = Resp.FraudResult
		///		
		///	    	If Object.Equals(FraudResp, Nothing) Then
		///	    		return
		///	    	EndIf
		///	    
		///	    FpsPreXmlData = FraudResp.Fps_PreXmlData
		///	    Rules = FpsPreXmlData.Rules()
		///	    Dim iCount As Integer
		///	    iCount = 0
		///	    For Each RuleType In Rules
		///	    
		///	        Console.WriteLine("ACTION FOR RULE ID - " + RuleType.RuleId + RuleType.Action)
		///	        Console.WriteLine("NUM FOR RULE ID - " + RuleType.RuleId + RuleType.Num)
		///	        Console.WriteLine("RULEALIAS FOR RULE ID - " + RuleType.RuleId + RuleType.RuleAlias)
		///	        Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId + RuleType.RuleDescription)
		///	        Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId + RuleType.TriggeredMessage)
		///	    
		///	        RuleVendorParams = RuleType.RuleVendorParms
		///	        For Each RuleVendorParamType In RuleVendorParams
		///	            Console.WriteLine("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Name)
		///	            Console.WriteLine("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Num)
		///	            Console.WriteLine("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Type)
		///	            Console.WriteLine("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Value)
		///	            iCount = iCount + 1
		///	        Next
		///	    Next
		///	    
		///	    FpsPostXmlData = FraudResp.Fps_PostXmlData
		///	    Rules = FpsPostXmlData.Rules()
		///	    For Each RuleType In Rules
		///	    
		///	        Console.WriteLine("RuleId" + RuleType.RuleId)
		///	        Console.WriteLine("ACTION FOR RULE ID - " + RuleType.RuleId + RuleType.Action)
		///	        Console.WriteLine("NUM FOR RULE ID - " + RuleType.RuleId + RuleType.Num)
		///	        Console.WriteLine("RULEALIAS FOR RULE ID - " + RuleType.RuleId + RuleType.RuleAlias)
		///	        Console.WriteLine("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId + RuleType.RuleDescription)
		///	        Console.WriteLine("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId + RuleType.TriggeredMessage)
		///	    
		///	        RuleVendorParams = RuleType.RuleVendorParms
		///	    
		///	        iCount = 0
		///	        For Each RuleVendorParamType In RuleVendorParams
		///	            Console.WriteLine("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Name)
		///	            Console.WriteLine("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Num)
		///	            Console.WriteLine("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Type)
		///	            Console.WriteLine("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId + RuleVendorParamType.Value)
		///	            iCount = iCount + 1
		///	        Next
		///	    Next
		/// </code>
		/// </example>
		public FpsXmlData()
		{
			mRules = new ArrayList();
		}

		#endregion

		#region "Functions"

	/*	/// <summary>
		/// Adds a rule to Rule list
		/// </summary>
		/// <param name="RuleObject">Rule object</param>
		internal void AddToRules(Rule RuleObject)
		{
			mRules.Add(RuleObject);
		}*/

//		/// <summary>
//		/// Clears the rule list
//		/// </summary>
//		internal void ClearRules()
//		{
//			mRules.Clear();
//		}

		/// <summary>
		/// Sets the rule list with another
		/// rule list
		/// </summary>
		/// <param name="RuleList">Rulelist</param>
		internal void SetRuleList(ArrayList RuleList)
		{
			mRules = RuleList;
		}

		#endregion
	}

}