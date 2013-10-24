find . -name "*cs" -exec git add {} \;
find . -name "*js" -exec git add {} \;
find . -name "*boo" -exec git add {} \;
git commit -m "Added all scripts"
