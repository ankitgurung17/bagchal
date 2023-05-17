using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLog : MonoBehaviour
{
    private List<GoatMovement> goatMovements = new List<GoatMovement>();
    
    public MovLog() {
        #region "Movements"
        //point 0,0
        {
            Vector2 point = new Vector2(0, 0);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 1));
            nodes.Add(new Vector2(1, 0));
            nodes.Add(new Vector2(1, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 0,1
        {
            Vector2 point = new Vector2(0, 1);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 0));
            nodes.Add(new Vector2(0, 2));
            nodes.Add(new Vector2(1, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 0,2
        {
            Vector2 point = new Vector2(0, 2);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 1));
            nodes.Add(new Vector2(0, 3));
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(1, 2));
            nodes.Add(new Vector2(1, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 0,3
        {
            Vector2 point = new Vector2(0, 3);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 2));
            nodes.Add(new Vector2(1, 2));
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(1, 4));
            nodes.Add(new Vector2(0, 4));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 0,4
        {
            Vector2 point = new Vector2(0, 4);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 3));
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(1, 4));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }

        //point 1,0
        {
            Vector2 point = new Vector2(1, 0);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 0));
            nodes.Add(new Vector2(1, 1));
            nodes.Add(new Vector2(2, 0));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 1,1
        {
            Vector2 point = new Vector2(1, 1);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 0));
            nodes.Add(new Vector2(0, 1));
            nodes.Add(new Vector2(0, 2));
            nodes.Add(new Vector2(1, 2));
            nodes.Add(new Vector2(2, 2));
            nodes.Add(new Vector2(2, 1));
            nodes.Add(new Vector2(2, 0));
            nodes.Add(new Vector2(1, 0));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 1,2
        {
            Vector2 point = new Vector2(1, 2);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 1));
            nodes.Add(new Vector2(0, 2));
            nodes.Add(new Vector2(0, 3));
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(2, 3));
            nodes.Add(new Vector2(2, 2));
            nodes.Add(new Vector2(2, 1));
            nodes.Add(new Vector2(1, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 1,3
        {
            Vector2 point = new Vector2(1, 3);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 2));
            nodes.Add(new Vector2(0, 3));
            nodes.Add(new Vector2(0, 4));
            nodes.Add(new Vector2(1, 4));
            nodes.Add(new Vector2(2, 4));
            nodes.Add(new Vector2(2, 3));
            nodes.Add(new Vector2(2, 2));
            nodes.Add(new Vector2(1, 2));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 1,4
        {
            Vector2 point = new Vector2(1, 4);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(0, 4));
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(2, 4));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }

        //point 2,0
        {
            Vector2 point = new Vector2(2, 0);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(1, 0));
            nodes.Add(new Vector2(1, 1));
            nodes.Add(new Vector2(2, 1));
            nodes.Add(new Vector2(3, 1));
            nodes.Add(new Vector2(3, 0));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 2,1
        {
            Vector2 point = new Vector2(2, 1);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(1, 1));
            nodes.Add(new Vector2(2, 2));
            nodes.Add(new Vector2(2, 0));
            nodes.Add(new Vector2(3, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 2,2
        {
            Vector2 point = new Vector2(2, 2);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(1, 1));
            nodes.Add(new Vector2(1, 2));
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(2, 3));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(3, 2));
            nodes.Add(new Vector2(3, 1));
            nodes.Add(new Vector2(2, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 2,3
        {
            Vector2 point = new Vector2(2, 3);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(2, 4));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(2, 2));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 2,4
        {
            Vector2 point = new Vector2(2, 4);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(1, 3));
            nodes.Add(new Vector2(1, 4));
            nodes.Add(new Vector2(2, 3));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(3, 4));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }

        //point 3,0
        {
            Vector2 point = new Vector2(3, 0);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(2, 0));
            nodes.Add(new Vector2(3, 1));
            nodes.Add(new Vector2(4, 0));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 3,1
        {
            Vector2 point = new Vector2(3, 1);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(2, 0));
            nodes.Add(new Vector2(2, 1));
            nodes.Add(new Vector2(2, 2));
            nodes.Add(new Vector2(3, 2));
            nodes.Add(new Vector2(4, 2));
            nodes.Add(new Vector2(4, 1));
            nodes.Add(new Vector2(4, 0));
            nodes.Add(new Vector2(3, 0));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 3,2
        {
            Vector2 point = new Vector2(3, 2);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(3, 1));
            nodes.Add(new Vector2(2, 2));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(4, 2));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 3,3
        {
            Vector2 point = new Vector2(3, 3);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(2, 2));
            nodes.Add(new Vector2(2, 3));
            nodes.Add(new Vector2(2, 4));
            nodes.Add(new Vector2(3, 4));
            nodes.Add(new Vector2(4, 4));
            nodes.Add(new Vector2(4, 3));
            nodes.Add(new Vector2(4, 2));
            nodes.Add(new Vector2(3, 2));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 3,4
        {
            Vector2 point = new Vector2(3, 4);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(2, 4));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(4, 4));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }

        //point 4,0
        {
            Vector2 point = new Vector2(4, 0);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(3, 0));
            nodes.Add(new Vector2(3, 1));
            nodes.Add(new Vector2(4, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 4,1
        {
            Vector2 point = new Vector2(4, 1);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(3, 1));
            nodes.Add(new Vector2(4, 2));
            nodes.Add(new Vector2(4, 0));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 4,2
        {
            Vector2 point = new Vector2(4, 2);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(3, 1));
            nodes.Add(new Vector2(3, 2));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(4, 3));
            nodes.Add(new Vector2(4, 1));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 4,3
        {
            Vector2 point = new Vector2(4, 3);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(4, 2));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(4, 4));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        //point 4,4
        {
            Vector2 point = new Vector2(4, 4);
            List<Vector2> nodes = new List<Vector2>();
            nodes.Add(new Vector2(4, 3));
            nodes.Add(new Vector2(3, 3));
            nodes.Add(new Vector2(3, 4));
            this.goatMovements.Add(new GoatMovement(point, nodes));
        }
        #endregion
    }
    
    public string[,] findMove(string[,] currBoard, float data) {
        bool isFoundHole = false;
        List<Vector2> tigers = new List<Vector2>();
        List<Vector2> holes = new List<Vector2>();
        List<Vector2> foundHoles = new List<Vector2>();
        for(int x = 0; x < 5; x++) { 
            for(int y = 0; y < 5; y++) { 
                if (currBoard[x, y] == "B") { 
                    tigers.Add(new Vector2(x, y));
                } 
            } 
        }
        foreach (GoatMovement movement in goatMovements) {
            foreach(Vector2 tiger in tigers) {
                if(tiger.Equals(movement.getPoint())) {
                    foreach(Vector2 holePoint in movement.getGoatMovements()) {
                        holes.Add(holePoint);
                    }
                }
            }
        }      
        foreach(Vector2 hole in holes) {
            int x = (int)hole.x, y = (int)hole.y;
            if(currBoard[x,y] == "") {
                isFoundHole = true;
                foundHoles.Add(new Vector2(x, y));
            }
        }
        if (isFoundHole) {
            int rangeMax = foundHoles.Count;
            int index = Random.Range(0, rangeMax - 1);
            currBoard[(int)foundHoles[index].x, (int)foundHoles[index].y] = "G";
        }
        else {
            Vector2 xy = new Vector2(-1,-1);
            //check for either hole is blank or not
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    if (currBoard[x, y] == "") {
                        currBoard[x, y] = "G";
                        return currBoard;
                    }
                }
            }
            if(xy.Equals(new Vector2(-1,-1))) {
                return null;
            }
        }
        return null;
    }
    
    class GoatMovement {
        Vector2 point;
        List<Vector2> goatMovementLists = new List<Vector2>();
        public GoatMovement(Vector2 point, List<Vector2> goatMovementLists) {
            this.point = point;
            this.goatMovementLists = goatMovementLists;
        }
        public Vector2 getPoint() {
            return this.point;
        }
        public List<Vector2> getGoatMovements() {
            return this.goatMovementLists;
        }
    }
}
