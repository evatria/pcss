package com.company;

import java.util.LinkedList;

public class Main {

    public static void main(String[] args) {

        GenericQueue<String> queueOfNames = new GenericQueue<>();

        queueOfNames.enqueue("Tom");
        queueOfNames.enqueue("George");
        queueOfNames.enqueue("Peter");

        System.out.println(queueOfNames.toString());

        queueOfNames.dequeue();

        System.out.println(queueOfNames.toString());


    }
}

class GenericQueue<E> extends LinkedList<E> {
    private static final long serialVersionUID = 1L;

    public void enqueue(E e){
        this.addFirst(e);
    }

    public void dequeue() {
        this.removeFirst();
    }

    public int getSize(){
        return this.size();
    }

    public String toString(){
        return "Queue: " + super.toString();
    }
}