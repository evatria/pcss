package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {

        LinkedList<String> ll = new LinkedList();

        ll.add("blue");
        ll.add("green");
        ll.add("yellow");
        ll.add("white");

        ll.addFirst("red");

        ListIterator iterator = ll.listIterator();

        while (iterator.hasNext()){
            System.out.println("step 1 " + iterator.next());
        }
        while (iterator.hasPrevious()){
            System.out.println("step 2 " + iterator.previous());
        }

        ll.addFirst(ll.removeLast());

        iterator = ll.listIterator();


        while (iterator.hasNext()){
            System.out.println("step 3 " + iterator.next());
        }
        while (iterator.hasPrevious()){
            System.out.println("step 4 " + iterator.previous());
        }

    }
}
