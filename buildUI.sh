cd technicalUI/
npx tsc

rc=$?

if [ ${rc} -ne 0 ]
then
    echo "ОШИБКА СБОРКИ"
else
    echo "СБОРКА ПРОШЛА УСПЕШНО"
fi

cmd /k
