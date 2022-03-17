import React, { useState, useEffect } from "react";
import MaterialTable from "material-table";
import tableIcons from "../shared/MaterialTableIcons";
import { Helmet } from "react-helmet";


const userList = [];

const UserListIn = () => {

  const [data, setData] = useState(userList);
  const [pageNumber, setPageNumber] = useState(1);
  const [totalRecords, setTotalRecords] = useState(0);

  const [isLoading, setIsLoading] = useState(true)

  const [displayTimeDiff, setDisplayTimeDiff] = useState(0)

  const columns = [
    { title: "Id", field: "id" },
    {
      title: "col4",
      field: "col4",
      render: (rowData) => (
        <img
          src={rowData.col4}
          style={{ width: "40px", borderRadius: "50%" }}
        />
      ),
    },
    { title: "Col1", field: "col1" },
    { title: "Col2", field: "col2" },
    { title: "Col5", field: "col5", type: "numeric" },
    { title: "Col6", field: "col6", type: "numeric" },
    {
      title: "Col7",
      field: "col7",
      type: "date",
      dateSetting: {
        format: "dd/MM/yyyy",
      },
    },
    { title: "Col10", field: "col10" },
  ];

  return (
    <div>
                  <Helmet>
                <title>Dot Net 5</title>
            </Helmet>
      <h1 className="myclassName">List Static Entity</h1>
      <h6>Fetching time : <b style={{color:'red'}}>{displayTimeDiff}</b> seconds</h6>

<MaterialTable
        icons={tableIcons}
        columns={columns}
        options={{debounceInterval:700,padding:"dense",filtering:true,search:false}}
        data={query =>
          new Promise((resolve, reject) => {

            let dStart = new Date()

            let url = '/Api/BigData/GetListEntityWhereIn?'
            if(query.search){
              url +=`q=${query.search}&`
            }
            if(query.orderBy){

              url += `&SortParameters.Field=${query.orderBy.field}&SortParameters.Sort=${query.orderDirection}`
            }
            if(query.filters.length){
              const filter =(query.filters.map(filter => {
                return `&${filter.column.field}${filter.operator}${filter.value}`
              }))
              url += filter.join('');
            }
            url += '&PaginationParameters.PageSize=' + query.pageSize
            url += '&PaginationParameters.PageNumber=' + (query.page + 1)
            fetch(url)
              .then(response => response.json())
              .then(result => {

                console.log(result);
                setData(result.data);
                setPageNumber(result.pageNumber);
                setTotalRecords(result.totalRecords);

                let dEnd = new Date();
                let diff = (dEnd.getTime() - dStart.getTime()) / 1000;
                setDisplayTimeDiff(diff);
                
                resolve({
                  data: result.data,
                  page: result.pageNumber - 1,
                  totalCount: result.totalRecords,
                })
              })
          })
        }
        title=""

      />
    </div>
  );
};

export default UserListIn;
