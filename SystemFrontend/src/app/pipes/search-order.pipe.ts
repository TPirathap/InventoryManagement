import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchOrder'
})
export class SearchOrderPipe implements PipeTransform {

  transform(items: any[], searchOrders: string): any {

    if (!items) {
      return [];
    }

      if (!searchOrders) {
        return items;
      }

      searchOrders = searchOrders.toLocaleLowerCase();
      return items.filter(it => {
        return it.ProductName.toLocaleLowerCase().indexOf(searchOrders)!=-1 || 
        it.CustomerFirstName.toLocaleLowerCase().indexOf(searchOrders)!=-1 || 
        it.CustomerLastName.toLocaleLowerCase().indexOf(searchOrders)!=-1 || 
        it.StatusDetail.toLocaleLowerCase().indexOf(searchOrders)!=-1;
      });
    
  }

}
