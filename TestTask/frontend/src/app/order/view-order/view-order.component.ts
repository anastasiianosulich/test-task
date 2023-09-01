import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { formatDateWithoutTime } from 'src/app/helpers/dateFormatter';
import { Order } from 'src/app/models/order';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-view-order',
  templateUrl: './view-order.component.html',
  styleUrls: ['./view-order.component.scss'],
})
export class ViewOrderComponent {
  order: Order | undefined = undefined;

  constructor(
    private route: ActivatedRoute,
    private ordersService: OrdersService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.setOrder(+id);
        }
      },
    });
  }

  setOrder(id: number) {
    this.ordersService.getOrderById(+id).subscribe({
      next: (order) => {
        this.order = order;

        this.order.creationDate = formatDateWithoutTime(
          this.order.creationDate
        );
      },
    });
  }
}
