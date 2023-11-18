#!/bin/bash

RED='\033[0;31m'
YELLOW='\033[1;33m'
GREEN='\033[0;32m'
NC='\033[0m'

touch output.txt

tests=$(ls ./testCases/*.test)
for test in $tests
do
  ./Lab1/bin/Release/net7.0/linux-x64/Lab1 < "$test" > output.txt
  expected=${test/.test/.expected}
  if diff output.txt "$expected"; then
    echo -e "${GREEN}[Test $test] done${NC}"
  else
    echo -e "${RED}[Test $test] failed ${NC}"
    echo -e "${YELLOW}Expected:${NC}"
    cat "$expected"
    echo -e "${YELLOW}Actual:${NC}"
    cat output.txt
    exit 1
  fi
done

rm output.txt
