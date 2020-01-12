///////////
//time.cs//
///////////
$CRPG5::StartTime = false;
$CRPG5::Time::Day = 0;
$CRPG5::Time::Month = 1;
$CRPG5::Time::Year = 1;

function PassTime()
{
	%d = $CRPG5::Time::Day;
	%m = $CRPG5::Time::Month;
	%y = $CRPG5::Time::Year;
	if($CRPG5::Time::Day >= 31 && (%m == 1 || %m == 3 || %m == 5 || %m == 7 || %m == 8 || %m == 10 || %m == 12))
	{
		$CRPG5::Time::Day = 0;
		$CRPG5::Time::Month++;
		//export("$CRPG5::Time*","config/server/CRPG5/time.cs");
	}
	if($CRPG5::Time::Day >= 30 && (%m == 4 || %m == 6 || %m == 9 || %m == 11))
	{
		$CRPG5::Time::Day = 0;
		$CRPG5::Time::Month++;
		//export("$CRPG5::Time*","config/server/CRPG5/time.cs");
	}
	if($CRPG5::Time::Day >= 28 && %m == 2)
	{
		$CRPG5::Time::Day = 0;
		$CRPG5::Time::Month++;
		//export("$CRPG5::Time*","config/server/CRPG5/time.cs");
	}
	if($CRPG5::Time::Month >= 12)
	{
		$CRPG5::Time::Day = 0;
		$CRPG5::Time::Month = 1;
		$CRPG5::Time::Year++;
		//export("$CRPG5::Time*","config/server/CRPG5/time.cs");
	}
	$CRPG5::Time::Day++;
	//export("$CRPG5::Time*","config/server/CRPG5/time.cs");
	
	if(%m == 1)
	{
		%m2 = "January";
	}
	if(%m == 2)
	{
		%m2 = "February";
	}
	if(%m == 3)
	{
		%m2 = "March";
	}
	if(%m == 4)
	{
		%m2 = "April";
	}
	if(%m == 5)
	{
		%m2 = "May";
	}
	if(%m == 6)
	{
		%m2 = "June";
	}
	if(%m == 7)
	{
		%m2 = "July";
	}
	if(%m == 8)
	{
		%m2 = "August";
	}
	if(%m == 9)
	{
		%m2 = "September";
	}
	if(%m == 10)
	{
		%m2 = "October";
	}
	if(%m == 11)
	{
		%m2 = "November";
	}
	if(%m == 12)
	{
		%m2 = "December";
	}
	
	if(%d == 1 || %d == 21)
	{
		%d2 = "st";
	}
	if(%d == 2 || %d == 22)
	{
		%d2 = "nd";
	}
	if(%d == 3 || %d == 23)
	{
		%d2 = "rd";
	}
    if (%d > 3 && (%d < 21 || %d > 23))
	{
		%d2 = "th";
	}
	if(%d == 31)
	{
		%d2 = "st";
	}
	messageAll("","\c6Today is the " @ %d @ %d2 @ " of " @ %m2 @ ", year " @ %y @ ".");
}

function CRPGTick()
{
	//300000
	PassTime();
	cancel($CRPG5Pass);
	$CRPG5Pass = schedule(1000,0,CRPGTick);
}
	
package CRPGTime
{
	function GameConnection::StartLoad(%client)
	{
		%t = $CRPG5::StartTime;
		if(%t == 0)
		{
			$CRPG5::StartTime = true;
			CRPGTick();
		}
		Parent::StartLoad(%client);
	}
};
activatepackage(CRPGTime);