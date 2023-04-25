#!/usr/bin/env bash

 
kubectl apply -f /home/gombka/developer/load-balancer/service-1.yml
kubectl apply -f /home/gombka/developer/load-balancer/service-2.yml
kubectl apply -f /home/gombka/developer/load-balancer/service-3.yml

kubectl apply -f /home/gombka/developer/load-balancer/ingress.yaml