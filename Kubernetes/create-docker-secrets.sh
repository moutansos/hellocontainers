#!/usr/bin/env bash

kubectl create secret docker-registry ghcr-login-secret --docker-server=https://ghcr.io --docker-username= --docker-password=$YOUR_GITHUB_TOKEN --docker-email=