function serverCmdQExec(%client)
{
	if(%client.isSuperAdmin)
	{
		exec("Add-ons/GameMode_CityRPGG5/server.cs");
		talk("Gamemode executed.");
	}
	else
	{
		return;
	}
}

//exec
exec("Add-ons/GameMode_CityRPG5/scripts/time.cs");

