import { Component, OnInit, TemplateRef } from '@angular/core';
import { HomeService } from './_core/_services/home.service';
import { NhapXuat } from './_core/_models/nhap-xuat';
import { NgSnotifyService } from './_core/_services/ng-snotify.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  soPhieuDelete: string = '';
  time_start: string = '';
  listData: NhapXuat[] = [];
  searchStr: string = '';
  modalRef?: BsModalRef;
  dataAdd: NhapXuat = <NhapXuat>{};
  bsConfig: Partial<BsDatepickerConfig> = <Partial<BsDatepickerConfig>>{
    isAnimated: true,
    dateInputFormat: 'DD/MM/YYYY',
  };
  constructor(private homeService: HomeService,
              private snotifyService: NgSnotifyService,
              private modalService: BsModalService) {}
  
  ngOnInit(): void {
    this.getData('');
  }
  getData(str: string) {
    this.homeService.getData(str).subscribe({
      next: (res) => {
        this.listData = res;
      }
    })
  }

  search() {
    this.getData(this.searchStr);
  }

  delete(model: NhapXuat) {
    this.snotifyService.confirm('Bạn có chắc chắn muốn xóa dữ liệu', 'Xóa', () => {
      this.homeService.delete(model).subscribe({
        next: (res) => {
          this.snotifyService.success('Xóa thành công', 'Xóa');
          this.getData('');
        }
      })
    })
  }

  functionDeleteSP() {
    if(!this.checkEmpty(this.soPhieuDelete)) {
      this.snotifyService.confirm('Bạn có chắc chắn muốn xóa dữ liệu', 'Xóa', () => {
        this.homeService.deleteSP(this.soPhieuDelete).subscribe({
          next: (res) => {
            if(res) {
              this.snotifyService.success('Xóa thành công', 'Xóa');
              this.modalRef?.hide();
              this.getData('');
            } else {
              this.snotifyService.error('Số phiếu này không tồn tại!!!', 'Cảnh báo');
            }
            
          }
        })
      })
    }
  }
  add() {
    if(this.checkEmpty(this.dataAdd.soPhieu) || 
      this.checkEmpty(this.dataAdd.ngayLapPhieu) ||
      this.checkEmpty(this.dataAdd.maVt) ||
      this.checkEmpty(this.dataAdd.tenVt) ||
      this.checkEmpty(this.dataAdd.dvt)) {
        this.snotifyService.error('Yêu cầu nhập hết các ô', 'Cảnh báo'!);
      } else {
        let text = this.dataAdd.ngayLapPhieu;
        this.dataAdd.ngayLapPhieu = this.getUTCDate(new Date(text));
        this.homeService.add(this.dataAdd).subscribe({
          next: (res) => {
            if(res) {
              this.snotifyService.success('Thêm thành công', 'Thành công!');
              this.getData('');
              this.modalRef?.hide();
            } else {
              this.snotifyService.success('Thêm lỗi', 'Cảnh báo');
            }
          }
        })
      }
  }
  getUTCDate(d?: Date) {
    let date = d ? d : new Date();
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  getDateFormat(date: Date) {
    return (
      date.getFullYear() +
      "/" +
      (date.getMonth() + 1 < 10
        ? "0" + (date.getMonth() + 1)
        : date.getMonth() + 1) +
      "/" +
      (date.getDate() < 10 ? "0" + date.getDate() : date.getDate())
    );
  }

  checkEmpty(str: any) {
    return !str || /^\s*$/.test(str);
  }
}
 