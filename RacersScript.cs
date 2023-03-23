void UpdateRacers(float deltaTimeS, List<Racer> racers)
{
    ////////////////////////////////
    //moved all variables to the top. Removed racerIndex as it was redundent after code changes
    ////////////////////////////////
    List<Racer> racersNeedingRemoved = new List<Racer>();
    List<Racer> newRacerList = new List<Racer>();

    ////////////////////////////////
    // removed racersNeedingRemoved.Clear() as the list is brand new each update
    //to further clarify I know creating a new list each time is bad but in order not to change the functionality I left it in here.
    ////////////////////////////////

    ////////////////////////////////
    //Did a foreach loop instead of a for loop. this means we dont need to access the racer index for the if
    ////////////////////////////////
    // Updates the racers that are alive   
    foreach (Racer racer in racers)
    {
        if (racer.IsAlive())
        {
            racer.Update(deltaTimeS * 1000.0f);
        }
    }

    // Collides
    for (int racerIndex1 = 0; racerIndex1 < racers.Count; racerIndex1++)
    {
        ////////////////////////////////
        //Check if racer1 is even collidable. if not then skip forward a loop
        ////////////////////////////////
        Racer racer1 = racers[racerIndex1];
        if (!racer1.IsCollidable()) continue;

        ////////////////////////////////
        //Sets racerIndex2 to racerIndex+1 since below we only check if racer 1 has collided with racer 2 so there is no need to check lower indexes for racer2 loop
        ////////////////////////////////
        for (int racerIndex2 = racerIndex1 + 1; racerIndex2 < racers.Count; racerIndex2++)
        {
            ////////////////////////////////
            //Check if racer2 is even collidable. if not then skip forward a loop            
            ////////////////////////////////
            Racer racer2 = racers[racerIndex2];
            if (!racer2.IsCollidable()) continue;

            if (racer1.CollidesWith(racer2))
            {
                OnRacerExplodes(racer1);
                racersNeedingRemoved.Add(racer1);
                OnRacerExplodes(racer2); //<<<<---- Added this as maybe racer 2 should be exploding too?
                racersNeedingRemoved.Add(racer2);
            }
        }
    }


    ////////////////////////////////
    //Did a foreach loop instead of a for loop. this means we dont need to access the racer index for the if
    ////////////////////////////////
    // Gets the racers that are still alive   
    foreach (Racer racer in racers)
    {
        // check if this racer must be removed
        ////////////////////////////////
        //runs a .Contains for the racer instead of using the index
        //I added a ! as I thought that if the car is in the needingRemoved list it shouldnt be added to the newRacerList
        ////////////////////////////////
        if (!racersNeedingRemoved.Contains(racer))
        {
            newRacerList.Add(racer);
        }
    }


    ////////////////////////////////
    //Again I did a foreach and a .Contains rather than doing an index check
    ////////////////////////////////
    // Get rid of all the exploded racers   
    foreach (Racer racer in racersNeedingRemoved)
    {
        if (racersNeedingRemoved.Contains(racer))
        {
            racer.Destroy();
            racers.Remove(racer);
        }
    }


    ////////////////////////////////
    ///No need to build up a list again as we can just write over it with the newRacerList
    ////////////////////////////////
    // Builds the list of remaining racers   
    racers = newRacerList;


    ////////////////////////////////
    //this loop below is not neccesery since a new newRacerList is created at the begining of the function and is therefor empty
    ////////////////////////////////
    //for (racerIndex = 0; racerIndex < newRacerList.Count; racerIndex++)
    //{
    //    newRacerList.RemoveAt(0);
    //}

    ////////////////////////////////
    // we could simplyclear the list in the same way that a list was cleared above
    newRacerList.Clear();
    ////////////////////////////////

}