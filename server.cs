$BR::Gamemode = "Office";
function serverCmdQExec(%client)
{
	if(%client.isSuperAdmin)
	{
		exec("Add-ons/GameMode_Office_Insurgency/server.cs");
		talk("Gamemode executed.");
	}
	else
	{
		return;
	}
}

//package OffIns
//{
//	function GameConnection::StartLoad(%this, %client)
//	{
//		talk("test");
//		Parent::StartLoad(%this, %client);
//	}
//};
//activatepackage(OffIns);

