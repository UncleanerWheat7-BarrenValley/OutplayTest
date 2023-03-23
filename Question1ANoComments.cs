void UpdateRacers(float deltaTimeS, List<Racer> racers)
{
    List<Racer> racersNeedingRemoved = new List<Racer>();
    List<Racer> newRacerList = new List<Racer>();
    
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
        Racer racer1 = racers[racerIndex1];
        if (!racer1.IsCollidable()) continue;
             
        for (int racerIndex2 = racerIndex1 + 1; racerIndex2 < racers.Count; racerIndex2++)
        {            
            Racer racer2 = racers[racerIndex2];
            if (!racer2.IsCollidable()) continue;

            if (racer1.CollidesWith(racer2))
            {
                OnRacerExplodes(racer1);
                racersNeedingRemoved.Add(racer1);
                OnRacerExplodes(racer2);
                racersNeedingRemoved.Add(racer2);
            }
        }
    }
    
    // Gets the racers that are still alive   
    foreach (Racer racer in racers)
    {        
        if (!racersNeedingRemoved.Contains(racer))
        {
            newRacerList.Add(racer);
        }
    }
    
    // Get rid of all the exploded racers   
    foreach (Racer racer in racersNeedingRemoved)
    {
        if (racersNeedingRemoved.Contains(racer))
        {
            racer.Destroy();
            racers.Remove(racer);
        }
    }

    // Builds the list of remaining racers   
    racers = newRacerList;
}