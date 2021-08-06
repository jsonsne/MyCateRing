

--房间类型测试数据
insert into DiTable(name,roomId)values('T1001',1);
insert into DiTable(name,roomId)values('T1002',1);
insert into DiTable(name,roomId)values('U1001',2);
insert into DiTable(name,roomId)values('F1001',3);
insert into DiTable(name,roomId)values('P1001',4);
insert into DiTable(name,roomId)values('X1001',5);
--餐桌测试数据
insert into RoomType(name,area,isZheKou,minConst,maxRenshu)values('大厅','一楼',0,50,10)
insert into RoomType(name,area,isZheKou,minConst,maxRenshu)values('大包厢','二楼',0,500,10)
insert into RoomType(name,area,isZheKou,minConst,maxRenshu)values('小包厢','二楼',0,250,10)
insert into RoomType(name,area,isZheKou,minConst,maxRenshu)values('豪华包厢','四楼',0,2050,10)
insert into RoomType(name,area,isZheKou,minConst,maxRenshu)values('情侣包厢','三楼',0,900,10)

select * from RoomType
select * from DiTable
 
 select * from RoomType r 
 join DiTable t
 on r.id =t.roomId
 where r.id=1
 

